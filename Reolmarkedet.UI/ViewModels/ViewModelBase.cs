using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Reolmarkedet.UI.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string Name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }

        //Sets the backing field and raises PropertyChanged only when the value has changed
        //To discuss with group if we should implement this?
        
        //protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        //{
        //    if (Equals(field, value))
        //        return false;
        //    field = value;
        //    OnPropertyChanged(propertyName);
        //    return true;
        //}

    }
}
