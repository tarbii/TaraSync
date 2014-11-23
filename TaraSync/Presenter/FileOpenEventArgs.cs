using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaraSync.Presenter
{
    public class FileOpenEventArgs : EventArgs
    {
        public readonly string Path;

        public FileOpenEventArgs(string path)
        {
            Path = path;
        }
    }
}
