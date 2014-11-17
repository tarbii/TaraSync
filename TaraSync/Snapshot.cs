using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaraSync
{
    class Snapshot
    {
        private const string InUseFileName = "in_use";
        private const string SnapshotFileName = "snapshot";

        private readonly SyncTarget syncTarget;
        private readonly string id;

        public bool IsInUse
        {
            get
            {
                return File.Exists(Path.Combine(syncTarget.AConfig, id, InUseFileName))
                    || File.Exists(Path.Combine(syncTarget.BConfig, id, InUseFileName));
            }
        }

        public Dictionary<string, string> Data
        {
            get
            {
                var fileName = Path.Combine(
                    File.Exists(Path.Combine(syncTarget.AConfig, id, SnapshotFileName))
                        ? syncTarget.AConfig
                        : syncTarget.BConfig,
                    id,
                    SnapshotFileName);

                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    var xmlS = new XmlSerializer(typeof(Dictionary<string, string>));
                    return (Dictionary<string, string>)xmlS.Deserialize(fs);
                }
            }
        }

        public Snapshot(SyncTarget syncTarget, string id)
        {
            this.syncTarget = syncTarget;
            this.id = id;
        }

        public void DeleteYourself()
        {
            Directory.Delete(Path.Combine(syncTarget.AConfig, id), true);
            Directory.Delete(Path.Combine(syncTarget.BConfig, id), true);
        }
    }
}
