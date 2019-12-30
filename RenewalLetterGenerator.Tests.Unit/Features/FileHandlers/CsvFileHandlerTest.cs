namespace RenewalLetterGenerator.Tests.Unit.Features.FileHandlers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Features.FileHandlers;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Test class to test the CsvFileHandler
    /// </summary>
    [TestClass]
    public class CsvFileHandlerTest
    {
        private CsvFileHandler underTest;

        private string fileDataPath = @"\App_Data\Customer.csv";

        private string filePath;

        [TestInitialize]
        public void TestInitialize()
        {
            underTest = new CsvFileHandler();
        }

        [TestMethod]
        public void TestCsvFileHandlerAsExpected()
        {
            GetTestFilePath();
            var value = underTest.ReadFile(filePath);
            Assert.IsNotNull(value);
            Assert.AreEqual(value.Count, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotProcessedException))]
        public void TestCsvFileHandlerWithEmptyPath()
        {
            underTest.ReadFile(string.Empty);
        }

        private void GetTestFilePath()
        {
            filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + fileDataPath;
        }
    }
}
