namespace RenewalLetterGenerator
{
    using Castle.Windsor;
    using RenewalLetterGenerator.Features;
    using RenewalLetterGenerator.Infrastructure;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new WindsorContainer();
            WindsorConfig.Install(container);

            var processEngine = container.Resolve<IProcessEngine>();
            processEngine.Start();
        }
    }
}
