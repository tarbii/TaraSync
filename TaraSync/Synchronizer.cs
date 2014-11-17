using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TaraSync
{
    class Synchronizer
    {
        public const string ConfigDirName = ".tarasync";


        private readonly SyncTarget syncTarget;

        public Synchronizer(SyncTarget syncTarget)
        {
            this.syncTarget = syncTarget;
        }

        public void Synchronize()
        {
            var snapshot = GetSnapshot();
            var xDir = snapshot == null ? new Dictionary<string, string>() : snapshot.Data;
            var aDir = GetAllFiles(syncTarget.A);
            var bDir = GetAllFiles(syncTarget.B);
            var syncId = Guid.NewGuid().ToString();

            foreach (var fileName in xDir.Keys.Union(aDir.Keys).Union(bDir.Keys))
            {
                var inA = aDir.ContainsKey(fileName);
                var inB = bDir.ContainsKey(fileName);
                var inX = xDir.ContainsKey(fileName);

                if (!inA && !inB && !inX) { } // never happens
                if (!inA && !inB && inX) { } // do nothig
                if (!inA && inB && !inX) // brand new file in B => copy from B to A
                {
                    File.Copy(
                        Path.Combine(syncTarget.B, fileName),
                        Path.Combine(syncTarget.A, fileName));
                }
                if (!inA && inB && inX)
                {
                    if (bDir[fileName] == xDir[fileName]) // file was deleted from A => del from B
                    {
                        File.Delete(Path.Combine(syncTarget.BConfig, fileName));
                    }
                    else // file was deleted from A but changed on B => ask user
                    {
                        var answer = GetConflictResolutionOption(fileName);
                        ResolveConflict(fileName, answer, syncId);
                    }
                }
                if (inA && !inB && !inX) // brand new file in A => copy from A to B
                {
                    File.Copy(
                        Path.Combine(syncTarget.A, fileName),
                        Path.Combine(syncTarget.B, fileName));
                }
                if (inA && !inB && inX)
                {
                    if (aDir[fileName] == xDir[fileName]) // file was deleted from B => del from A
                    {
                        File.Delete(Path.Combine(syncTarget.AConfig, fileName));
                    }
                    else // file was deleted from B but changed on A => ask user
                    {
                        var answer = GetConflictResolutionOption(fileName);
                        ResolveConflict(fileName, answer, syncId);
                    }
                }
                if (inA && inB && !inX)
                {
                    if (aDir[fileName] == bDir[fileName]) { }
                    // same brand new file in both folders => do nothing
                    else
                    {
                        var answer = GetConflictResolutionOption(fileName);
                        ResolveConflict(fileName, answer, syncId);
                    }
                }
                if (inA && inB && inX)
                {
                    if (aDir[fileName] == bDir[fileName]) { } // same file => do nothing
                    else
                    {
                        if (aDir[fileName] == xDir[fileName])
                        // file in B was changed => copy from B to A
                        {
                            File.Copy(
                                Path.Combine(syncTarget.B, fileName),
                                Path.Combine(syncTarget.A, fileName));
                        }
                        if (bDir[fileName] == xDir[fileName])
                        // file in A was changed => copy from A to B
                        {
                            File.Copy(
                                Path.Combine(syncTarget.A, fileName),
                                Path.Combine(syncTarget.B, fileName));
                        }
                        var answer = GetConflictResolutionOption(fileName);
                        ResolveConflict(fileName, answer, syncId);
                    }
                }
            }
        }

        private void ResolveConflict(string fileName, UserOptions answer, string syncId)
        {
            //What to do with files?
            
            switch (answer)
            {
                case 0:
                    File.Copy(
                                Path.Combine(syncTarget.A, fileName),
                                Path.Combine(
                                syncTarget.B, 
                                Path.GetFileNameWithoutExtension(fileName) 
                                + syncId
                                +Path.GetExtension(fileName)));
                    File.Copy(
                                Path.Combine(syncTarget.B, fileName),
                                Path.Combine(
                                syncTarget.A, 
                                Path.GetFileNameWithoutExtension(fileName)
                                + syncId
                                + Path.GetExtension(fileName)));
                    break;
                default:
                    File.Copy(
                                Path.Combine(syncTarget.A, fileName),
                                Path.Combine(
                                syncTarget.B,
                                Path.GetFileNameWithoutExtension(fileName)
                                + syncId
                                + Path.GetExtension(fileName)));
                    File.Copy(
                                Path.Combine(syncTarget.B, fileName),
                                Path.Combine(
                                syncTarget.A,
                                Path.GetFileNameWithoutExtension(fileName)
                                + syncId
                                + Path.GetExtension(fileName)));
                    break;
            }
        }

        private UserOptions GetConflictResolutionOption(string fileName)
        {
            return UserOptions.SaveBoth;
        }

        private enum UserOptions
        {
            SaveBoth
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

        private static Dictionary<string, string> GetAllFiles(string path)
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
                var directoryName = Path.GetDirectoryName(directory);
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
