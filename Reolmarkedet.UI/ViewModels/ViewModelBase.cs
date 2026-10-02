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

        //OnPropertyChanged() metoden kaldes property ændres for at give UI besked om ændring
        //[CallerMemberName] = indsætter automatisk navnet på property
        //string Name = null = gør parameteren valgfri, så vi kan kalde metoden uden et arguement
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name)) = kalder PropertyChanged eventet 
        //og sender besked om hvilken property der er ændret til UI
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
