using System;

namespace TaraSync.Presenter
{
    interface IView
    {
        void ShowMessage(string message);
        event EventHandler<SyncRequestEventArgs> SyncRequested;
    }
}