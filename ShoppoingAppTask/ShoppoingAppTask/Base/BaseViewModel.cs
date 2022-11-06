using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShoppoingAppTask.Base
{
    public class BaseViewModel : BaseNotifiedModel
    {
        private bool isBusy;
        public virtual bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (SetProperty(ref isBusy, value))
                    OnPropertyChanged(nameof(IsIdle));
            }
        }
        public bool IsIdle => !IsBusy;

    }
    public abstract class BaseNotifiedModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event Xamarin.Forms.PropertyChangingEventHandler PropertyChanging;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null, Action onChanged = null, Action<T> onChanging = null, bool raiseOnEqual = false)
        {
            if (!raiseOnEqual && EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            onChanging?.Invoke(value);

            OnPropertyChanging(storage, propertyName);

            storage = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);

            return true;
        }

        protected void OnPropertyChanging(object oldValue, [CallerMemberName] string propertyName = null)
        {
            PropertyChanging?.Invoke(this, new Xamarin.Forms.PropertyChangingEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
