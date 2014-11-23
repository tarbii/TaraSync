using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaraSync.Presenter
{
    public class FileCreateEventArgs
    {
        public readonly string Path;

        public FileCreateEventArgs(string path)
        {
            Path = path;
        }
    }
}
