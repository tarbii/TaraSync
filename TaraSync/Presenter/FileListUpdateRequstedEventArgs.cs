using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaraSync.Presenter
{
    public class FileListUpdateRequstedEventArgs
    {
        public readonly string Path;
        public readonly FolderRepresentPosition Position;

        public FileListUpdateRequstedEventArgs(string path, FolderRepresentPosition position)
        {
            Path = path;
            Position = position;
        }
    }
}
