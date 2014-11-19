using System;
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
            var sync = new Synchronizer(new SyncTarget(e.PathA, e.PathB));

            try
            {
                sync.Synchronize();
            }
            catch (Exception ex)
            {
                view.ShowMessage("Failed with exception " + ex);
            }

            view.ShowMessage("Done");
        }
        
    }
}
