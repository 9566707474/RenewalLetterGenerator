namespace RenewalLetterGenerator.Infrastructure
{
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class WindsorConfig
    {
        public static void Install(IWindsorContainer container)
        {
            container.Install(FromAssembly.This());
        }
    }
}
