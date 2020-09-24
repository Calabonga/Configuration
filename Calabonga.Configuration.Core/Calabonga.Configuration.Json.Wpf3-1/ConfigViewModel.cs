using System.Collections.Specialized;

namespace Calabonga.Configuration.Core.Wpf3_1
{
    public class ConfigViewModel : ViewModelBase
    {
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _name;
    }
}
