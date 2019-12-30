namespace RenewalLetterGenerator.Features.DataExtractor
{
    using RenewalLetterGenerator.Models;
    using System.Collections.Generic;

    public interface IDataExtractor
    {
        ICollection<CustomerProduct> GetCustomerProductsFromFile(string fileHandlerType, string filePath);
    }
}
