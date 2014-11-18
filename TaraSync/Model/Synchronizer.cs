using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace TaraSync.Model
{
    public class Synchronizer
    {
        public const string ConfigDirName = ".tarasync";


        private readonly SyncTarget syncTarget;

        public Synchronizer(SyncTarget syncTarget)
        {
            this.syncTarget = syncTarget;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="syncIdTest">For test only</param>
        public void Synchronize(string syncIdTest = null)
        {
            var snapshot = GetSnapshot();
            var xDir = snapshot == null ? new Dictionary<string, string>() : snapshot.Data;
            var aDir = GetAllFiles(syncTarget.A);
            var bDir = GetAllFiles(syncTarget.B);
            var syncId = syncIdTest ?? Guid.NewGuid().ToString();

            foreach (var fileName in xDir.Keys.Union(aDir.Keys).Union(bDir.Keys))
            {
                var inA = aDir.ContainsKey(fileName);
                var inB = bDir.ContainsKey(fileName);
                var inX = xDir.ContainsKey(fileName);

                var option = ConflictResolutionOption.None;

                // never happens
                if (!inA && !inB && !inX) option = ConflictResolutionOption.None; 
                // do nothig
                if (!inA && !inB && inX) option = ConflictResolutionOption.None;
                // brand new file in B => copy from B to A
                if (!inA && inB && !inX) option = ConflictResolutionOption.UseB;
                // file was deleted from A => del from B -OR- file was deleted from A but changed on B => ask user
                if (!inA && inB && inX)
                {
                    option = bDir[fileName] == xDir[fileName] 
                        ? ConflictResolutionOption.UseA
                        : GetConflictResolutionOption(fileName);
                }
                // brand new file in A => copy from A to B
                if (inA && !inB && !inX) option = ConflictResolutionOption.UseA;
                // file was deleted from B => del from A -OR- file was deleted from B but changed on A => ask user
                if (inA && !inB && inX)
                {
                    option = aDir[fileName] == xDir[fileName]
                        ? ConflictResolutionOption.UseB 
                        : GetConflictResolutionOption(fileName);
                }
                // same brand new file in both folders => do nothing -OR- not same => ask user
                if (inA && inB && !inX)
                {
                    option = aDir[fileName] == bDir[fileName]
                        ? ConflictResolutionOption.None
                        : GetConflictResolutionOption(fileName);
                }
                if (inA && inB && inX)
                {
                    // same file => do nothing
                    if (aDir[fileName] == bDir[fileName]) option = ConflictResolutionOption.None; 
                    // file in B was changed => copy from B to A
                    else if (aDir[fileName] == xDir[fileName]) option = ConflictResolutionOption.UseB;
                    // file in A was changed => copy from A to B
                    else if (bDir[fileName] == xDir[fileName]) option = ConflictResolutionOption.UseA;
                    else option = GetConflictResolutionOption(fileName); 
                }

                ResolveConflict(fileName, option, syncId);
            }

            Directory.CreateDirectory(syncTarget.AConfig);
            Directory.CreateDirectory(Path.Combine(syncTarget.AConfig, syncId));
            Directory.CreateDirectory(syncTarget.BConfig);
            Directory.CreateDirectory(Path.Combine(syncTarget.BConfig, syncId));
            var newSnapshot = GetAllFiles(syncTarget.A);
            //SerializeSnapshot(newSnapshot, syncId);
        }

        public void SerializeSnapshot(Dictionary<string, string> data, string syncId)
        {
            var fileName = Path.Combine(syncTarget.AConfig, syncId, "snapshot");
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var xmlS = new XmlSerializer(data.GetType());
                xmlS.Serialize(fs, data);
            }
        }
        private void ResolveConflict(string fileName, ConflictResolutionOption option, string syncId)
        {
            var name = Path.GetFileNameWithoutExtension(fileName);
            var ext = Path.GetExtension(fileName);
            var names = new
            {
                A = Path.Combine(syncTarget.A, fileName),
                AA = Path.Combine(syncTarget.A,
                    string.Format("{0}.{1}.{2}{3}", name, "A", syncId, ext)),
                AB = Path.Combine(syncTarget.A,
                    string.Format("{0}.{1}.{2}{3}", name, "B", syncId, ext)),
                B = Path.Combine(syncTarget.B, fileName),
                BA = Path.Combine(syncTarget.B,
                    string.Format("{0}.{1}.{2}{3}", name, "A", syncId, ext)),
                BB = Path.Combine(syncTarget.B,
                    string.Format("{0}.{1}.{2}{3}", name, "B", syncId, ext)),
            };

            if ((option & ConflictResolutionOption.RenameA) != ConflictResolutionOption.None)
            {
                File.Move(names.A, names.AA);
                File.Copy(names.AA, names.BA);
            }
            if ((option & ConflictResolutionOption.RenameB) != ConflictResolutionOption.None)
            {
                File.Move(names.B, names.BB);
                File.Copy(names.BB, names.AB);
            }
            if ((option & ConflictResolutionOption.UseA) != ConflictResolutionOption.None)
            {
                if (File.Exists(names.A))
                {
                    File.Copy(names.A, names.B, true);
                }
                else
                {
                    File.Delete(names.B);
                }
            }
            if ((option & ConflictResolutionOption.UseB) != ConflictResolutionOption.None)
            {
                if (File.Exists(names.B))
                {
                    File.Copy(names.B, names.A, true);
                }
                else
                {
                    File.Delete(names.A);
                }
            }
        }

        private ConflictResolutionOption GetConflictResolutionOption(string fileName)
        {
#if DEBUG
            return ConflictResolutionOption.RenameBoth;
#else
            throw new NotImplementedException();
#endif
        }

        [Flags]
        public enum ConflictResolutionOption
        {
            None = 0,

            UseA = 1,
            UseB = 2,
            RenameA = 4,
            RenameB = 8,

            RenameBoth = RenameA | RenameB,
            RenameAUseB = RenameA | UseB,
            RenameBUseA = RenameB | UseA,
        }

        private Snapshot GetSnapshot()
        {
            if (!syncTarget.BothConfigsExist)
            {
                return null;
            }

            var allSyncIds = Directory.EnumerateDirectories(syncTarget.AConfig)
                    .Intersect(Directory.EnumerateDirectories(syncTarget.BConfig));

            var snapshots = allSyncIds.Select(id => new Snapshot(syncTarget, id)).ToList();

            var snapshotInUse = snapshots.FirstOrDefault(s => s.IsInUse);
            var snapshotNotInUse = snapshots.FirstOrDefault(s => !s.IsInUse);

            if (snapshotInUse != null && snapshotNotInUse == null)
            {
                return AskUser(snapshotInUse);
            }

            if (snapshotInUse != null)
            {
                snapshotInUse.DeleteYourself();
            }
            return snapshotNotInUse;
        }

        private Snapshot AskUser(Snapshot snapshotInUse)
        {
            //todo ask user what option to use
            //1. continue current sync (warn that it is insecure if any changes were made)
            //2. start new sync as if none was ever done
            return null;
        }

        public static Dictionary<string, string> GetAllFiles(string path)
        {
            var allFiles = new Dictionary<string, string>();
            GetAllFilesRecursion(path, "", allFiles);
            return allFiles;
        }

        private static void GetAllFilesRecursion(string rootPath, string relativePath,
            Dictionary<string, string> data)
        {
            var currentPath = Path.Combine(rootPath, relativePath);
            foreach (var file in Directory.EnumerateFiles(currentPath))
            {
                data[Path.Combine(relativePath, Path.GetFileName(file))] = GetFileHash(file);
            }

            foreach (var directory in Directory.EnumerateDirectories(currentPath))
            {
                var directoryName = Path.GetFileName(directory);
                if (relativePath == "" && directoryName == ConfigDirName)
                {
                    continue;
                }
                GetAllFilesRecursion(rootPath, Path.Combine(relativePath, directoryName), data);
            }
        }

        private static string GetFileHash(string filePath)
        {
            using (var hashFunc = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(hashFunc.ComputeHash(stream));
                }
            }
        }


    }
}
