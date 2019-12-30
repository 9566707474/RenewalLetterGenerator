namespace RenewalLetterGenerator.Features.OutputFileHandler
{
    using RenewalLetterGenerator.Common;
    using RenewalLetterGenerator.Exceptions;
    using RenewalLetterGenerator.Models;
    using System;

    /// <summary>
    /// Used to Generate invitation letter
    /// </summary>
    public class GenerateOutputFile
    {
        public CustomerProduct CustomerProduct { get; set; }

        public IFileSystem FileSystem { get; set; }

        public string FilePath { get; set; }

        /// <summary>
        /// Start to generate the invitation letter
        /// </summary>
        public void Start()
        {
            try
            {
                if (!FilePath.EndsWith("\\"))
                {
                    FilePath = FilePath + "\\";
                }

                FilePath = FilePath + CustomerProduct.Id + "_" + CustomerProduct.FirstName + FileTypes.Text;

                var invitationTemplate = OutputTemplate.Get;

                foreach (var keyValue in OutputMapping.Columns)
                {
                    invitationTemplate = invitationTemplate.Replace(keyValue.Key, GetPropertyValue(CustomerProduct, keyValue.Value).ToString());
                }

                if (!FileSystem.FileExists(FilePath))
                {
                    FileSystem.WriteAllText(FilePath, invitationTemplate);
                }
            }
            catch (Exception ex)
            {
                throw new InvitationNotGeneratedException(ex.Message);
            }
        }

        /// <summary>
        /// Get property value by name
        /// </summary>
        /// <param name="source">source object</param>
        /// <param name="propertyName">property name</param>
        /// <returns>property value as object</returns>
        private static object GetPropertyValue(object source, string propertyName)
        {
            var propertyInfo = source.GetType().GetProperty(propertyName);
            return propertyInfo.GetValue(source, null);
        }
    }
}
