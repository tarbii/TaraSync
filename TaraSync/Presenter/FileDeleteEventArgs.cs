using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaraSync.Presenter
{
    public class FileDeleteEventArgs : EventArgs
    {
        public readonly string Path;

        public FileDeleteEventArgs(string path)
        {
            Path = path;
        }
    }
}
