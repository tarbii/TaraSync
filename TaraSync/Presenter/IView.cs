using System;

namespace TaraSync.Presenter
{
    interface IView
    {
        void ShowMessage(string message);
        
        void UpdateProgress(string stage, int progress, int count);
        
        event EventHandler<SyncRequestEventArgs> SyncRequested;

    }
}