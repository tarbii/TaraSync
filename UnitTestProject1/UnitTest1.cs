using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaraSync;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSynchronizationResult()
        {
            var sync = new Synchronizer(
                 new SyncTarget(
                     @"TestCases\Case1\A",
                     @"TestCases\Case1\B"));

            sync.Synchronize();
        }
    }
}
