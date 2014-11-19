using System;
using System.Threading;
using TaraSync.Model;

namespace TaraSync.Presenter
{
    class Presenter
    {
        private readonly IView view;
        public Presenter(IView newView)
        {
            view = newView;
            view.SyncRequested += view_SyncRequested;
        }

        void view_SyncRequested(object sender, SyncRequestEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                var sync = new Synchronizer(new SyncTarget(e.PathA, e.PathB));
                sync.ProgressUpdated += sync_ProgressUpdated;
                try
                {
                    sync.Synchronize();
                }
                catch (Exception ex)
                {
                    view.ShowMessage("Failed with exception " + ex);
                }

                view.ShowMessage("Done");
                sync.ProgressUpdated -= sync_ProgressUpdated;
            });
        }

        void sync_ProgressUpdated(object sender, ProgressUpdatedEventArgs e)
        {
            view.UpdateProgress(e.Stage, e.Progress, e.Count);
        }
        
    }
}
