using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaraSync;
using TaraSync.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSynchronizationResult()
        {
            const string caseDirSource = @"TestCases\Case1";
            const string caseDir = @"work\TestCases\Case1";

            if (Directory.Exists(caseDir))
            {
                Directory.Delete(caseDir, true);
            }
            DirectoryCopy(caseDirSource, caseDir, true);

            var aDir = Path.Combine(caseDir, "A");
            var bDir = Path.Combine(caseDir, "B");
            var cDir = Path.Combine(caseDir, "C");

            var sync = new Synchronizer(new SyncTarget(aDir, bDir));

            sync.Synchronize("6bfce438-b4a9-455f-9495-2be38ba314d6");

            var a = Synchronizer.GetAllFiles(aDir);
            var b = Synchronizer.GetAllFiles(bDir);
            var c = Synchronizer.GetAllFiles(cDir);

            foreach (var filename in a.Keys.Union(b.Keys).Union(c.Keys))
            {
                Assert.IsTrue(a.ContainsKey(filename), 
                    string.Format("No {0} in {1}", filename, aDir));
                Assert.IsTrue(b.ContainsKey(filename),
                    string.Format("No {0} in {1}", filename, bDir));
                Assert.IsTrue(c.ContainsKey(filename), 
                    string.Format("No {0} in {1}", filename, cDir));
                Assert.AreEqual(a[filename], b[filename],
                    string.Format("{0} differs in A and B", filename));
                Assert.AreEqual(a[filename], c[filename],
                    string.Format("{0} differs in A and C", filename));
                Assert.AreEqual(b[filename], c[filename],
                    string.Format("{0} differs in B and C", filename));
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
