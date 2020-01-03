namespace RenewalLetterGenerator.Features
{
    using RenewalLetterGenerator.Common;
    using RenewalLetterGenerator.Features.DataExtractor;
    using RenewalLetterGenerator.Features.OutputFileHandler;
    using RenewalLetterGenerator.Features.Rules;
    using RenewalLetterGenerator.Models;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    /// <summary>
    /// Process engine heart of the application.
    /// Match the files based on pattern confiogured in config file.
    /// Extract the customer products from the files.
    /// Calculate the payment amounts by applying multiple rules.
    /// Generate the invitation latter for each customer product respectivly. 
    /// </summary>
    public class ProcessEngine : IProcessEngine
    {
        private readonly IFileSystem fileSystem;

        private readonly IConfigurationManagerFacade ConfigurationManagerFacade;

        private readonly IDataExtractor dataExtractor;

        private static readonly string UnderscoreSymbol = "_";

        public ProcessEngine(IConfigurationManagerFacade ConfigurationManagerFacade, IFileSystem fileSystem, IDataExtractor dataExtractor)
        {
            this.fileSystem = fileSystem;
            this.ConfigurationManagerFacade = ConfigurationManagerFacade;
            this.dataExtractor = dataExtractor;
        }

        /// <summary>
        /// Start to generate the invitation letter
        /// </summary>
        public void Start()
        {
            var files = fileSystem.GetFiles(ConfigurationManagerFacade.InputFileLocation, ConfigurationManagerFacade.InputFilePattern);

            foreach (var item in files)
            {
                var fileType = fileSystem.GetFileType(item);
                var customerProducts = dataExtractor.GetCustomerProductsFromFile(fileType, item);

                var templatePath = GetExecutionPath() + Constants.OutputTemplatePath;

                OutputTemplate.Load = this.fileSystem.ReadAllText(templatePath);

                var customerProductList = ApplyPaymentCalculationRules(customerProducts);

                WriteOutput(customerProductList);
            }
        }

        /// <summary>
        /// Applying payment calculation rules by using parallel task
        /// </summary>
        /// <param name="customerProducts"> collection of customer product</param>
        /// <returns></returns>
        private ICollection<CustomerProduct> ApplyPaymentCalculationRules(ICollection<CustomerProduct> customerProducts)
        {
            var payments = new ConcurrentBag<Payments>();
            foreach (var item in customerProducts)
            {
                payments.Add(new Payments(item));
            }

            var parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = ConfigurationManagerFacade.NumberOfProcessor };

            Parallel.ForEach(payments, parallelOptions, task =>
            {
                task.Calculate();
            });

            return payments.Select(p => p.CustomerProduct).ToList();
        }

        /// <summary>
        /// Generate the output for each customer products
        /// </summary>
        /// <param name="customerProducts">collectuion of customer products</param>
        private void WriteOutput(ICollection<CustomerProduct> customerProducts)
        {
            var generateOutputFile = new ConcurrentBag<GenerateOutputFile<CustomerProduct>>();
            foreach (var item in customerProducts)
            {
                generateOutputFile.Add(new GenerateOutputFile<CustomerProduct>()
                {
                    GenericProperty = item,
                    FileSystem = fileSystem,
                    FilePath = Path.Combine(ConfigurationManagerFacade.OutputFileLocation, string.Concat(item.Id, UnderscoreSymbol, item.Surname, FileTypes.Text))
                });
            }

            var parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = ConfigurationManagerFacade.NumberOfProcessor };

            Parallel.ForEach(generateOutputFile, parallelOptions, task =>
            {
                task.Start();
            });
        }

        /// <summary>
        /// Get the execution path to load output template
        /// </summary>
        /// <returns></returns>
        private static string GetExecutionPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

    }
}
