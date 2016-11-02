using System;
using System.Collections.Generic;
using System.IO;
using VIK.Core.Entities;

namespace VIK.Core.FileModule
{
    class FileManager
    {
        public string filePath { get; set; }
        private Dictionary<string,string> files { get; set; }

        public FileManager()
        {
            filePath = AppDomain.CurrentDomain.BaseDirectory;
        }

        public Dictionary<string, string> RecoverFileDictionary()
        {
            files = new Dictionary<string, string>();

            DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            foreach (var fi in di.GetFiles("*.xml"))
            {
                files.Add(fi.Name, fi.FullName);
            }

            return files;
        }

        public List<FileEntity> RecoverFileList()
        {
            List<FileEntity> fileList = new List<FileEntity>();

            DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            foreach (var fi in di.GetFiles("*.xml"))
            {
                fileList.Add(new FileEntity(fi));
            }

            return fileList;
        }
    }
}
