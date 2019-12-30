namespace RenewalLetterGenerator.Tests.Unit.Common
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RenewalLetterGenerator.Common;
    using System;
    using System.Collections.Specialized;

    /// <summary>
    /// Test class to test the ConfigurationManagerFacade
    /// </summary>
    [TestClass]
    public class ConfigurationManagerFacadeTest
    {
        private IConfigurationManagerFacade configuration;

        private string numberOfProcessor;

        private string inputFileLocation;

        private string inputFilePattern;

        private string outputFileLocation;

        [TestInitialize]
        public void TestInitialize()
        {
            numberOfProcessor = "4";
            inputFileLocation = @"C:\Test";
            inputFilePattern = ".CSV";
            outputFileLocation = @"C:\Test";

            var settings = new NameValueCollection() {
                {Constants.NumberOfProcessor,numberOfProcessor},
                {Constants.InputFileLocation,inputFileLocation },
                {Constants.InputFilePattern,inputFilePattern },
                {Constants.OutputFileLocation,outputFileLocation},
            };

            configuration = new ConfigurationManagerFacade(settings);
        }

        [TestMethod]
        public void CanGetNumberOfProcessor()
        {
            Assert.AreEqual(Convert.ToInt32(numberOfProcessor), configuration.NumberOfProcessor);
        }

        [TestMethod]
        public void CanGetInputFileLocation()
        {
            Assert.AreEqual(inputFileLocation, configuration.InputFileLocation);
        }

        [TestMethod]
        public void CanGetInputFilePattern()
        {
            Assert.AreEqual(inputFilePattern, configuration.InputFilePattern);
        }

        [TestMethod]
        public void CanGetOutputFileLocation()
        {
            Assert.AreEqual(outputFileLocation, configuration.OutputFileLocation);
        }
    }
}
