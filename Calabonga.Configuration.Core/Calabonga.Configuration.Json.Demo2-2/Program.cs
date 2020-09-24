using System;
using Autofac;

namespace Calabonga.Configuration.Core.Demo2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DependencyContainer.Create();

            var configuration = container.Resolve<AppConfiguration>();
            var settings = configuration.Config;

            Console.WriteLine($"Hello World! [settings.Name={settings.Name}]");
        }


    }
}
