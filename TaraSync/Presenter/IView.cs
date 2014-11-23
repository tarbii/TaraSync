using System;
using System.Collections.Generic;
using System.IO;

namespace TaraSync.Presenter
{
    interface IView
    {
        void ShowMessage(string message);
        
        void UpdateProgress(string stage, int progress, int count);

        void UpdateFileList(FolderRepresentPosition position, IEnumerable<FileInfo> fileList);

        event EventHandler<SyncRequestEventArgs> SyncRequested;
        event EventHandler<FileListUpdateRequstedEventArgs> FileListUpdateRequsted;
        event EventHandler<FileOpenEventArgs> FileOpen;
        event EventHandler<FileDeleteEventArgs> FileDelete;
        event EventHandler<FileCreateEventArgs> FileCreate;

    }
}