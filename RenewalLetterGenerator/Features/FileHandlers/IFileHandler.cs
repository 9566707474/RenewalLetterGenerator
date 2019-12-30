namespace RenewalLetterGenerator.Features.FileHandlers
{
    using RenewalLetterGenerator.Models;
    using System.Collections.Generic;

    public interface IFileHandler
    {
        string Type { get; }

        ICollection<CustomerProduct> ReadFile(string filePath);
    }
}
