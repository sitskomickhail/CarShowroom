using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CarShowroom.Annotations;

namespace CarShowroom.ViewModel.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract Task SetDefaultValues();
    }
}