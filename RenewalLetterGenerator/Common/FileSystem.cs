namespace RenewalLetterGenerator.Common
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileSystem: IFileSystem
    {
        public string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public bool FileExists(string filePath)
        {
            if (Directory.Exists(Path.GetDirectoryName(filePath)) && File.Exists(filePath))
            {
                return true;
            }

            return false;
        }

        public void CreateFile(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        public void WriteAllText(string filePath,string content)
        {
            File.WriteAllText(filePath,content);
        }

        public ICollection<string> GetFiles(string directoryPath,string pattern)
        {
            return Directory.GetFiles(directoryPath, pattern).ToList();
        }

        public string GetFileType(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            return fileInfo.Extension.ToUpper();
        }

    }
}
