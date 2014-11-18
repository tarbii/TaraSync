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
            const string
                aDir = @"TestCases\Case1\A",
                bDir = @"TestCases\Case1\B",
                cDir = @"TestCases\Case1\C";

            var sync = new Synchronizer(new SyncTarget(aDir, bDir));

            sync.Synchronize("6bfce438-b4a9-455f-9495-2be38ba314d6");

            var a = Synchronizer.GetAllFiles(aDir);
            var b = Synchronizer.GetAllFiles(bDir);
            var c = Synchronizer.GetAllFiles(cDir);

            foreach (var filename in a.Keys.Union(b.Keys).Union(c.Keys))
            {
                Assert.IsTrue(a.ContainsKey(filename), string.Format("No {0} in {1}", filename, aDir));
                Assert.IsTrue(b.ContainsKey(filename), string.Format("No {0} in {1}", filename, bDir));
                Assert.IsTrue(c.ContainsKey(filename), string.Format("No {0} in {1}", filename, cDir));
                Assert.AreEqual(a[filename], b[filename], string.Format("{0} differs in A and B", filename));
                Assert.AreEqual(a[filename], c[filename], string.Format("{0} differs in A and C", filename));
                Assert.AreEqual(b[filename], c[filename], string.Format("{0} differs in B and C", filename));
            }
        }
    }
}
