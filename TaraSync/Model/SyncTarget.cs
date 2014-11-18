using System.IO;

namespace TaraSync.Model
{
    public class SyncTarget
    {
        public readonly string A;
        public readonly string AConfig;
        public readonly string B;
        public readonly string BConfig;

        public bool BothConfigsExist
        {
            get { return Directory.Exists(AConfig) && Directory.Exists(BConfig); }
        }

        public SyncTarget(string a, string b)
        {
            A = a;
            AConfig = Path.Combine(A, Synchronizer.ConfigDirName);
            B = b;
            BConfig = Path.Combine(B, Synchronizer.ConfigDirName);
        }
    }
}
