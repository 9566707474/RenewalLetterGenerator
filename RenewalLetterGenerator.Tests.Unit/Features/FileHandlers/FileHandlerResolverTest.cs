namespace RenewalLetterGenerator.Tests.Unit.Features.FileHandlers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using RenewalLetterGenerator.Features.FileHandlers;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Test class to test the FileHandlerResolver
    /// </summary>
    [TestClass]
    public class FileHandlerResolverTest
    {
        private FileHandlerResolver underTest;

        private IEnumerable<IFileHandler> fileHandlers;

        private string fileHandlerType;

        [TestInitialize]
        public void TestInitialize()
        {
            fileHandlers = new List<IFileHandler>() { new CsvFileHandler() };
            fileHandlerType = ".CSV";
            underTest = new FileHandlerResolver(fileHandlers);
        }

        [TestMethod]
        public void TestFileHandlerResolverAsExpected()
        {
            var value = underTest.Resolve(fileHandlerType);
            Assert.IsNotNull(value);
            Assert.IsInstanceOfType(value, typeof(CsvFileHandler));
        }

        [TestMethod]        
        [ExpectedException(typeof(ArgumentException))]
        public void TestFileHandlerResolverWithOtherTypes()
        {
            underTest.Resolve("test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFileHandlerResolverWithNullValue()
        {
            underTest.Resolve(null);
        }
    }
}
