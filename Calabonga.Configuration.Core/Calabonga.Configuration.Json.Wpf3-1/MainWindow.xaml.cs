using System.Windows;
using Autofac;
using Calabonga.Configuration.Core.Demo2_2;

namespace Calabonga.Configuration.Core.Wpf3_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var configuration = ((App)Application.Current).Container.Resolve<AppConfiguration>();
            DataContext = configuration.Config;
        }
    }
}
