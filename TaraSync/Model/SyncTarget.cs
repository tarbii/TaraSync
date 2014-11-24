using System.IO;

namespace TaraSync.Model
{
    public class SyncTarget
    {
        public readonly string A;
        public readonly string B;

        public string AConfig
        {
            get { return Path.Combine(A, Synchronizer.ConfigDirName); }
        }

        public string BConfig
        {
            get { return Path.Combine(B, Synchronizer.ConfigDirName); }
        }

        public bool BothConfigsExist
        {
            get { return Directory.Exists(AConfig) && Directory.Exists(BConfig); }
        }

        public SyncTarget(string a, string b)
        {
            A = a;
            B = b;
        }
    }
}
