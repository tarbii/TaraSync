﻿using System;
using System.Threading;
using System.Windows.Forms;
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
            view.FileListUpdateRequsted += view_FileListUpdateRequsted;
        }

        void view_FileListUpdateRequsted(object sender, FileListUpdateRequstedEventArgs e)
        {
            view.UpdateFileList(e.Position, FileEditor.GetFiles(e.Path));
        }

        bool syncIsOn = false;
        
        void view_SyncRequested(object sender, SyncRequestEventArgs e)
        {
            if (syncIsOn)
            {
                MessageBox.Show(
                    "Another synchrinization is in progress. Wait untill it is over.");
                return;
            }
            ThreadPool.QueueUserWorkItem(delegate
            {
                syncIsOn = true;
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
                syncIsOn = false;
            });
        }

        void sync_ProgressUpdated(object sender, ProgressUpdatedEventArgs e)
        {
            view.UpdateProgress(e.Stage, e.Progress, e.Count);
        }
        
    }
}
