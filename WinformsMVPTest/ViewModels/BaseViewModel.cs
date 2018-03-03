using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinformsMVPTest.ViewModels
{
    //Just in case
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
