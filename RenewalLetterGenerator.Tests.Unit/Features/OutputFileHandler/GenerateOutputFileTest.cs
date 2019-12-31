namespace RenewalLetterGenerator.Tests.Unit.Features.OutputFileHandler
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using RenewalLetterGenerator.Common;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Features.OutputFileHandler;
    using RenewalLetterGenerator.Models;
    using RenewalLetterGenerator.Tests.Unit.Builders.Models;

    /// <summary>
    /// Test class to test GenerateOutputFile
    /// </summary>
    [TestClass]
    public class GenerateOutputFileTest
    {
        private GenerateOutputFile<CustomerProduct> underTest;

        private Mock<IFileSystem> mockFileSystem;

        private string filePath;

        private CustomerProduct customerProduct;

        private string loadTemplate;

        [TestInitialize]
        public void TestInitialize()
        {
            mockFileSystem = new Mock<IFileSystem>();
            filePath = string.Empty;
            loadTemplate = string.Empty;

            underTest = new GenerateOutputFile<CustomerProduct>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvitationNotGeneratedException))]
        public void TestGenerateOutputFileWithEmptyCustomerProduct()
        {
            underTest = new GenerateOutputFile<CustomerProduct>() { GenericProperty = customerProduct, FileSystem = mockFileSystem.Object, FilePath = filePath };
            underTest.Start();
        }

        [TestMethod]
        public void TestGenerateOutputFileAsExpected()
        {
            customerProduct = BuildCustomerProduct();
            OutputTemplate.Load = loadTemplate;
            var filePath = string.Concat(customerProduct.Id, '_', customerProduct.FirstName);
            underTest = new GenerateOutputFile<CustomerProduct>() { GenericProperty = customerProduct, FileSystem = mockFileSystem.Object, FilePath = filePath };
            underTest.Start();

            Assert.AreEqual(underTest.FilePath, filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(InvitationNotGeneratedException))]
        public void TestGenerateOutputFileWithoutOutputTemplate()
        {
            customerProduct = BuildCustomerProduct();
            OutputTemplate.Load = null;
            underTest = new GenerateOutputFile<CustomerProduct>() { GenericProperty = customerProduct, FileSystem = mockFileSystem.Object, FilePath = filePath };
            underTest.Start();
        }

        private CustomerProduct BuildCustomerProduct()
        {
            return new CustomerProductModelBuilder().WithAnnualPremium(50).Build();
        }
    }
}
