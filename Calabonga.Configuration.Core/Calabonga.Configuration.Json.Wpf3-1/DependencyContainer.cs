using Autofac;

namespace Calabonga.Configuration.Core.Demo2_2
{
    public static class DependencyContainer
    {
        public static IContainer Create()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JsonConfigurationSerializer>().As<IConfigurationSerializer>();
            builder.RegisterType<AppConfiguration>().As<IConfiguration<AppSettings>>();
            builder.RegisterType<AppConfiguration>().AsSelf();
            
            return builder.Build();
        }
        
    }
}
