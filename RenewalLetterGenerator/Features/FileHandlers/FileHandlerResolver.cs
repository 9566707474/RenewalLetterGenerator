namespace RenewalLetterGenerator.Features.FileHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// File handler resolver used to achive the dependency injection 
    /// </summary>
    public class FileHandlerResolver : IFileHandlerResolver
    {
        private readonly IEnumerable<IFileHandler> fileHandler;

        public FileHandlerResolver(IEnumerable<IFileHandler> fileHandler)
        {
            this.fileHandler = fileHandler;
        }

        /// <summary>
        /// Get the type of file handler based on file type
        /// </summary>
        /// <param name="fileType">file extention as file type</param>
        /// <returns>IFileHandler type object</returns>
        public IFileHandler Resolve(string fileType)
        {
            var fileHandler = this.fileHandler.FirstOrDefault(item => item.Type == fileType);

            if (fileHandler == null)
            {
                throw new ArgumentException("File handler not found", fileType);
            }
            return fileHandler;
        }
    }
}
