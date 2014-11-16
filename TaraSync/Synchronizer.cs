using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaraSync
{
    class Synchronizer
    {
        public const string ConfigDirName = ".tarasync";
        public IEnumerable<string> GetAllSyncIds(SyncTarget syncTarget)
        {
            var set = new HashSet<string>(Directory.EnumerateDirectories(syncTarget.AConfig));
            set.IntersectWith(Directory.EnumerateDirectories(syncTarget.BConfig));
            return set;
        }

        public Snapshot GetSnapshot(SyncTarget syncTarget, IEnumerable<string> allSyncIds)
        {

            var snapshots = allSyncIds.Select(id => new Snapshot(syncTarget, id)).ToList();

            var snapshotInUse = snapshots.FirstOrDefault(s => s.IsInUse);
            var snapshotNotInUse = snapshots.FirstOrDefault(s => !s.IsInUse);

            if (snapshotInUse == null && snapshotNotInUse == null)
            {
                return null;
            }

            if (snapshotInUse == null)
            {
                return snapshotNotInUse;
            }

            if (snapshotNotInUse == null)
            {
                return AskUser();
            }
            else
            {
                Directory.Delete(inu);
                return snapshotNotInUse;
            }
        }

        private Snapshot AskUser()
        {
            throw new NotImplementedException();
        }
    }
}
