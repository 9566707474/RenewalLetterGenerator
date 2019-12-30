namespace RenewalLetterGenerator.Features.DataExtractor
{
    using RenewalLetterGenerator.Features.FileHandlers;
    using RenewalLetterGenerator.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Used to extract the customer product data from the given file
    /// </summary>
    public class DataExtractor : IDataExtractor
    {
        private readonly IFileHandlerResolver fileHandlerResolver;

        public DataExtractor(IFileHandlerResolver fileHandlerResolver)
        {
            this.fileHandlerResolver = fileHandlerResolver;
        }

        /// <summary>
        /// Get customer products from the given file
        /// </summary>
        /// <param name="fileHandlerType">File handler type</param>
        /// <param name="filePath">File path</param>
        /// <returns>Collection of CustomerProduct</returns>
        public ICollection<CustomerProduct> GetCustomerProductsFromFile(string fileHandlerType, string filePath)
        {
            var fileHandler = this.fileHandlerResolver.Resolve(fileHandlerType);

            var customerProducts = fileHandler.ReadFile(filePath);

            return customerProducts;
        }
    }
}
