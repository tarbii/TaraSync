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

        public Snapshot GetSnapshot()
        {
            if (!syncTarget.BothConfigsExist)
            {
                return null;
            }

            var allSyncIds = new HashSet<string>(
                Directory.EnumerateDirectories(syncTarget.AConfig));
            allSyncIds.IntersectWith(
                Directory.EnumerateDirectories(syncTarget.BConfig));
            
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
