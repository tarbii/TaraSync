using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaraSync.Model
{
    public class ProgressUpdatedEventArgs : EventArgs
    {
        public readonly string Stage;
        public readonly int Progress;
        public readonly int Count;

        public ProgressUpdatedEventArgs(string stage, int progress, int count)
        {
            Stage = stage;
            Progress = progress;
            Count = count;
        }
    }
}
