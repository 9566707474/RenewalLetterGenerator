using System.Collections.Generic;

namespace RenewalLetterGenerator.Common
{
    public interface IFileSystem
    {
        string ReadAllText(string filePath);

        bool FileExists(string filePath);

        void CreateFile(string filePath);

        void WriteAllText(string filePath, string content);

        ICollection<string> GetFiles(string directoryPath, string pattern);

        string GetFileType(string filePath);
    }
}
