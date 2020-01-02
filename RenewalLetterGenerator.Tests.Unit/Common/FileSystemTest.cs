namespace RenewalLatterGenerator.Tests.Unit.Common
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RenewalLetterGenerator.Common;
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Test class to test the FileSystem
    /// </summary>
    [TestClass]
    public class FileSystemTest
    {
        private static IFileSystem fileSystem;

        private static string fileName;

        private static string filePattern;

        [TestInitialize]
        public void TestInitialize()
        {
            fileSystem = new FileSystem();
            fileName = @"\App_Data\Customer.csv";
            filePattern = "*.csv";
        }

        [TestMethod]
        public void TestInstanceOfType()
        {
            Assert.IsInstanceOfType(fileSystem, typeof(IFileSystem));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateFileWithNullFilePath()
        {
            fileSystem.CreateFile(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateFileWithEmptyFilePath()
        {
            fileSystem.CreateFile(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void TestCreateFileWithUnknownDirctoryFilePath()
        {
            fileSystem.CreateFile(@"Q:\test\test");
        }

        [TestMethod]
        public void TestCreateFileAsExpected()
        {
            var file = GetExecutionPath() + fileName;
            fileSystem.CreateFile(file);
        }

        [TestMethod]
        public void TestFileExistsAsExpected()
        {
            var file = GetExecutionPath() + fileName;
            var value = fileSystem.FileExists(file);
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void TestReadAllTextAsExpected()
        {
            var file = GetExecutionPath() + fileName;
            var value = fileSystem.ReadAllText(file);
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Length > 0);
        }

        [TestMethod]
        public void TestGetFileTypeAsExpected()
        {
            var file = GetExecutionPath() + fileName;
            var value = fileSystem.GetFileType(file);
            Assert.IsNotNull(value);
            Assert.AreEqual(value,".CSV");
        }

        #region Private methods
        private string GetExecutionPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        #endregion
    }
}
