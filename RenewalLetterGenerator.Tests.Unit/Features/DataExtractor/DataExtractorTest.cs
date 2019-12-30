namespace RenewalLetterGenerator.Tests.Unit.Features.DataExtractor
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using RenewalLetterGenerator.Features.DataExtractor;
    using RenewalLetterGenerator.Features.FileHandlers;
    using RenewalLetterGenerator.Models;
    using RenewalLetterGenerator.Tests.Unit.Builders.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Test class to test the DataExtractor
    /// </summary>
    [TestClass]
    public class DataExtractorTest
    {
        private DataExtractor underTest;

        private Mock<IFileHandlerResolver> mockFileHandlerResolver;

        private Mock<IFileHandler> mockFileHandler;

        private string fileHandlerType;

        private string filePath;

        [TestInitialize]
        public void TestInitialize()
        {
            mockFileHandlerResolver = new Mock<IFileHandlerResolver>();
            mockFileHandler = new Mock<IFileHandler>();

            fileHandlerType = ".csv";
            filePath = string.Empty;
            underTest = new DataExtractor(mockFileHandlerResolver.Object);
        }

        [TestMethod]
        public void TestDataExtractorAsExpectedWithEmptyCustomerProduct()
        {
            MockFileHandlerResolver();
            MockFileHandler(new List<CustomerProduct>());
            var value = underTest.GetCustomerProductsFromFile(fileHandlerType,filePath);

            Assert.IsNotNull(value);
            Assert.AreEqual(value.Count,0);
        }

        [TestMethod]
        public void TestDataExtractorAsExpected()
        {
            var expectedProducts = BuildCustomerProductList();
            MockFileHandlerResolver();
            MockFileHandler(expectedProducts);
            var value = underTest.GetCustomerProductsFromFile(fileHandlerType, filePath);

            Assert.IsNotNull(value);
            Assert.AreEqual(value.Count, expectedProducts.Count);
        }

        private ICollection<CustomerProduct> BuildCustomerProductList()
        {
            return new List<CustomerProduct>() {
                new CustomerProductModelBuilder().Build(),
                new CustomerProductModelBuilder().WithId(2).Build(),
            };
        }

        private void MockFileHandlerResolver()
        {
            mockFileHandlerResolver.Setup(m => m.Resolve(fileHandlerType)).Returns(mockFileHandler.Object);
        }

        private void MockFileHandler(ICollection<CustomerProduct> customerProducts)
        {
            mockFileHandler.Setup(m => m.ReadFile(filePath)).Returns(customerProducts);
        }
    }
}
