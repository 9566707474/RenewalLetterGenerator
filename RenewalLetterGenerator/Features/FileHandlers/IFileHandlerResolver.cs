namespace RenewalLetterGenerator.Features.FileHandlers
{
    public interface IFileHandlerResolver
    {
        IFileHandler Resolve(string fileHandlerType);
    }
}
