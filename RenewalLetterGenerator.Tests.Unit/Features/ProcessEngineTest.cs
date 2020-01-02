namespace RenewalLetterGenerator.Tests.Unit.Features
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using RenewalLetterGenerator.Common;
    using RenewalLetterGenerator.Features;
    using RenewalLetterGenerator.Features.DataExtractor;
    using RenewalLetterGenerator.Models;
    using RenewalLetterGenerator.Tests.Unit.Builders.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Test class to test the ProcessEngine
    /// </summary>
    [TestClass]
    public class ProcessEngineTest
    {
        private ProcessEngine underTest;

        private Mock<IFileSystem> mockFileSystem;

        private Mock<IDataExtractor> mockDataExtractor;

        private Mock<IConfigurationManagerFacade> mockConfigurationManagerFacade;

        private string inputFileLocation;

        private string inputFilePattern;

        private string fileName;

        private string outputTemplatePath;

        [TestInitialize]
        public void TestInitialize()
        {
            mockFileSystem = new Mock<IFileSystem>();
            mockDataExtractor = new Mock<IDataExtractor>();
            mockConfigurationManagerFacade = new Mock<IConfigurationManagerFacade>();

            inputFileLocation = @"C\test\";

            inputFilePattern = ".CSV";

            fileName = string.Empty;

            outputTemplatePath = GetExecutionPath() + Constants.OutputTemplatePath;

            underTest = new ProcessEngine(mockConfigurationManagerFacade.Object, mockFileSystem.Object, mockDataExtractor.Object);
        }

        [TestMethod]
        public void TestProcessEngineAsExpected()
        {
            SetupMockConfigurationManagerFacade();
            SetupMockFileSystemGetFiles(new List<string> { fileName });
            SetupMockFileSystemGetFileType(fileName);
            SetupMockFileSystemReadAllText(outputTemplatePath, string.Empty);
            SetupMockDataExtractor(fileName, BuildCustomerProductList());
            underTest.Start();
            mockFileSystem.Verify(m => m.GetFiles(inputFileLocation, inputFilePattern), Times.Once);
            mockFileSystem.Verify(m => m.GetFileType(fileName), Times.Once);
            mockFileSystem.Verify(m => m.ReadAllText(outputTemplatePath), Times.Once);
            mockDataExtractor.Verify(m => m.GetCustomerProductsFromFile(inputFilePattern, fileName), Times.Once);
        }

        [TestMethod]
        public void TestProcessEngineAsExpectedWithZeroFileCount()
        {
            SetupMockConfigurationManagerFacade();
            SetupMockFileSystemGetFiles(new List<string>());
            underTest.Start();
            mockFileSystem.Verify(m => m.GetFiles(inputFileLocation, inputFilePattern), Times.Once);
            mockFileSystem.Verify(m => m.GetFileType(fileName), Times.Never);
            mockFileSystem.Verify(m => m.ReadAllText(outputTemplatePath), Times.Never);
            mockDataExtractor.Verify(m => m.GetCustomerProductsFromFile(inputFilePattern, fileName), Times.Never);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestProcessEngineAsExpectedWithNullFileSystem()
        {
            SetupMockConfigurationManagerFacade();
            SetupMockFileSystemGetFiles(null);
            underTest.Start();
        }

        #region Private methods

        private ICollection<CustomerProduct> BuildCustomerProductList()
        {
            return new List<CustomerProduct>() {
                new CustomerProductModelBuilder().Build(),
                new CustomerProductModelBuilder().WithId(2).Build(),
            };
        }

        private void SetupMockConfigurationManagerFacade()
        {
            mockConfigurationManagerFacade.Setup(m => m.InputFileLocation).Returns(inputFileLocation);
            mockConfigurationManagerFacade.Setup(m => m.InputFilePattern).Returns(inputFilePattern);
            mockConfigurationManagerFacade.Setup(m => m.OutputFileLocation).Returns(inputFileLocation);
        }

        private void SetupMockFileSystemGetFiles(ICollection<string> fileNames)
        {
            mockFileSystem.Setup(m => m.GetFiles(inputFileLocation, inputFilePattern)).Returns(fileNames);
        }

        private void SetupMockFileSystemGetFileType(string fileName)
        {
            mockFileSystem.Setup(m => m.GetFileType(fileName)).Returns(inputFilePattern);
        }

        private void SetupMockFileSystemReadAllText(string fileName, string output)
        {
            mockFileSystem.Setup(m => m.ReadAllText(fileName)).Returns(output);
        }

        private void SetupMockDataExtractor(string fileName, ICollection<CustomerProduct> customerProducts)
        {
            mockDataExtractor.Setup(m => m.GetCustomerProductsFromFile(inputFilePattern, fileName)).Returns(customerProducts);
        }

        private static string GetExecutionPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        #endregion
    }
}
