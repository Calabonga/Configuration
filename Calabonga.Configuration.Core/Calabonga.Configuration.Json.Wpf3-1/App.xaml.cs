using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Calabonga.Configuration.Core.Demo2_2;

namespace Calabonga.Configuration.Core.Wpf3_1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IContainer Container { get; set; }

        /// <inheritdoc />
        protected override void OnStartup(StartupEventArgs e)
        {
            Container = DependencyContainer.Create();

            base.OnStartup(e);
        }
    }


}
