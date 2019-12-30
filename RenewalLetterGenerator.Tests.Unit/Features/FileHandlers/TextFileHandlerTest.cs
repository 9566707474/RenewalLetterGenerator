namespace RenewalLetterGenerator.Tests.Unit.Features.FileHandlers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RenewalLetterGenerator.Features.FileHandlers;
    using System;

    /// <summary>
    /// Test class to test the TextFileHandler
    /// </summary>
    [TestClass]
    public class TextFileHandlerTest
    {
        private TextFileHandler underTest;

        [TestInitialize]
        public void TestInitialize()
        {
            underTest = new TextFileHandler();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestCsvFileHandlerWithEmptyPath()
        {
            underTest.ReadFile(string.Empty);
        }
    }
}
