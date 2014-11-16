using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaraSync
{
    class Snapshot
    {
        private readonly SyncTarget syncTarget;
        private readonly string id;

        public bool IsInUse
        {
            get
            {
                
            }
        }

        public Snapshot(SyncTarget syncTarget, string id)
        {
            this.syncTarget = syncTarget;
            this.id = id;
        }
    }
}
