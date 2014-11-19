using System;

namespace TaraSync.Presenter
{
    public class SyncRequestEventArgs : EventArgs
    {
        public readonly string PathA;
        public readonly string PathB;

        public SyncRequestEventArgs(string pathA, string pathB)
        {
            PathA = pathA;
            PathB = pathB;
        }
    }
}