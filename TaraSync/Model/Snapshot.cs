using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace TaraSync.Model
{
    class Snapshot
    {
        private const string InUseFileName = "in_use";
        private const string SnapshotFileName = "snapshot";

        private readonly SyncTarget syncTarget;
        public readonly string Id;

        public bool IsInUse
        {
            get
            {
                return File.Exists(Path.Combine(syncTarget.AConfig, Id, InUseFileName))
                    || File.Exists(Path.Combine(syncTarget.BConfig, Id, InUseFileName));
            }
            set
            {
                if (value)
                {
                    File.WriteAllText(Path.Combine(syncTarget.AConfig, Id, InUseFileName), "");
                }
                else
                {
                    throw new ArgumentException("IsInUse can only be set 'true'", "value");
                }
            }
        }

        public Dictionary<string, string> Data
        {
            get
            {
                var fileName = Path.Combine(
                    File.Exists(Path.Combine(syncTarget.AConfig, Id, SnapshotFileName))
                        ? syncTarget.AConfig
                        : syncTarget.BConfig,
                    Id,
                    SnapshotFileName);

                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    var serializer = new DataContractJsonSerializer(
                        typeof(Dictionary<string, string>));
                    return (Dictionary<string, string>)serializer.ReadObject(fs);
                }
            }
        }

        public static void SerializeSnapshot(Dictionary<string, string> data, 
            SyncTarget syncTarget)
        {
            var id = Guid.NewGuid().ToString();
            Directory.CreateDirectory(Path.Combine(syncTarget.AConfig, id));
            Directory.CreateDirectory(Path.Combine(syncTarget.BConfig, id));
            var fileName = Path.Combine(syncTarget.AConfig, id, "snapshot");
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var serializer = new DataContractJsonSerializer(data.GetType());
                serializer.WriteObject(fs, data);
            }
        }

        public Snapshot(SyncTarget syncTarget, string id)
        {
            this.syncTarget = syncTarget;
            this.Id = id;
        }

        public void DeleteYourself()
        {
            Directory.Delete(Path.Combine(syncTarget.AConfig, Id), true);
            Directory.Delete(Path.Combine(syncTarget.BConfig, Id), true);
        }
    }
}
