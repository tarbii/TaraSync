using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TaraSync.Model
{
    class FileEditor
    {
        public static void RemoveFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void CreateFile(string filePath)
        {
            if (File.Exists(filePath))
            {

            }
            else
            {
                using (File.Create(filePath)) { }
            }
        }

        public static void EditFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (Process.Start(filePath)) { }
            }

        }

        public static IEnumerable<FileInfo> GetFiles(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                return new DirectoryInfo(folderPath).EnumerateFiles("*", SearchOption.AllDirectories); 
            }
            return null;
        }
    }
}
