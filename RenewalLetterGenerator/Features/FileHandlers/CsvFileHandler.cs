namespace RenewalLetterGenerator.Features.FileHandlers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using RenewalLetterGenerator.Common;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Models;

    /// <summary>
    /// Csv file parser class
    /// </summary>
    public class CsvFileHandler : IFileHandler
    {
        private const char Delimiter = ',';

        public CsvFileHandler()
        {
            Type = FileTypes.Csv;
        }

        public string Type { get; private set; }

        /// <summary>
        /// Read the file and assign the data to CustomerProduct objects
        /// </summary>
        /// <param name="filePath">Input file path</param>
        /// <returns>Collection of CustomerProduct</returns>
        public ICollection<CustomerProduct> ReadFile(string filePath)
        {
            try
            {
                int i = 0;
                var customerProducts = new List<CustomerProduct>();

                foreach (var item in File.ReadLines(filePath))
                {
                    if (i == 0)
                    {
                        i = i + 1;
                        continue;
                    }

                    customerProducts.Add(GetCustomerProductFromLine(item));
                }

                return customerProducts;
            }
            catch (Exception ex)
            {
                throw new FileNotProcessedException(ex.Message);
            }
           
        }

        /// <summary>
        /// Get the customer products from each line
        /// </summary>
        /// <param name="line">Line from text file</param>
        /// <returns>CustomerProduct object</returns>
        private CustomerProduct GetCustomerProductFromLine(string line)
        {
            var attributes = line.Split(Delimiter);

            if (attributes != null && attributes.Length == 7)
            {
                return new CustomerProduct()
                {
                    Id = Convert.ToInt64(attributes[0]),
                    Title = attributes[1],
                    FirstName = attributes[2],
                    Surname = attributes[3],
                    ProductName = attributes[4],
                    PayoutAmount = Convert.ToDouble(attributes[5]),
                    AnnualPremium = Convert.ToDouble(attributes[6]),
                };
            }
            else
            {
                throw new FileNotProcessedException("Incorrect collumns found");
            }
        }
    }
}
