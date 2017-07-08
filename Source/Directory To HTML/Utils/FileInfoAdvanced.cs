using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryToHtml.Utils
{
    class FileInfoAdvanced
    {
        public FileInfo File { get; set; }
        public string FileName { get; set; }
        public string FolderName { get; set; }
        public long SizeByte { get; set; }
        public double SizeKiB { get; set; }
        public double SizeMiB { get; set; }
        public double SizeGiB { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public FileInfoAdvanced(FileInfo f, string fold)
        {
            // File Name
            FileName = f.Name;

            // Folder Name
            FolderName = fold;

            // Size Bytes
            SizeByte = f.Length;

            // Size KiB
            double size = f.Length;
            size = size / 1024;
            SizeKiB = size;

            // Size MiB
            size = size / 1024;
            SizeMiB = size;

            // Size GiB
            size = size / 1024;
            SizeGiB = size;

            // Creation Date
            CreationDate = f.CreationTime;

            // Last Modification Date
            ModificationDate = f.LastWriteTime;
        }
    }
}
