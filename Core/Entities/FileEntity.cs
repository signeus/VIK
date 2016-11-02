using System.IO;

namespace VIK.Core.Entities
{
    class FileEntity
    {
        public string Extension { get; set; }
        public string DirectoryName { get; set; }
        public DirectoryInfo Directory { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Filename { get; set; }

        public FileEntity(FileInfo file)
        {
            Extension = file.Extension;
            DirectoryName = file.DirectoryName;
            Directory = file.Directory;
            FullName = file.FullName;
            Name = file.Name;
            Filename = file.Name.Replace(Extension, "");
        }
    }
}
