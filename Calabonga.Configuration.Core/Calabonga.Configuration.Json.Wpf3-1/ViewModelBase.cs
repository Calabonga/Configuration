using System.ComponentModel;

namespace Calabonga.Configuration.Core.Wpf3_1
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion INotifyPropertyChanged
    }
}