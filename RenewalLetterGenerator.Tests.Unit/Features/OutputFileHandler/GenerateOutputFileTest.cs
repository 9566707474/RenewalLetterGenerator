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
        private GenerateOutputFile underTest;

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

            underTest = new GenerateOutputFile();
        }

        [TestMethod]
        [ExpectedException(typeof(InvitationNotGeneratedException))]
        public void TestGenerateOutputFileWithEmptyCustomerProduct()
        {
            underTest = new GenerateOutputFile() { CustomerProduct = customerProduct, FileSystem = mockFileSystem.Object, FilePath = filePath };
            underTest.Start();
        }

        [TestMethod]
        public void TestGenerateOutputFileAsExpected()
        {
            customerProduct = BuildCustomerProduct();
            OutputTemplate.Load = loadTemplate;
            underTest = new GenerateOutputFile() { CustomerProduct = customerProduct, FileSystem = mockFileSystem.Object, FilePath = filePath };
            underTest.Start();
            var fileName = string.Concat(customerProduct.Id, '_', customerProduct.FirstName);
            Assert.IsTrue(underTest.FilePath.Contains(fileName));
        }

        [TestMethod]
        [ExpectedException(typeof(InvitationNotGeneratedException))]
        public void TestGenerateOutputFileWithoutOutputTemplate()
        {
            customerProduct = BuildCustomerProduct();
            OutputTemplate.Load = null;
           underTest = new GenerateOutputFile() { CustomerProduct = customerProduct, FileSystem = mockFileSystem.Object, FilePath = filePath };
            underTest.Start();
        }

        private CustomerProduct BuildCustomerProduct()
        {
            return new CustomerProductModelBuilder().WithAnnualPremium(50).Build();
        }
    }
}
