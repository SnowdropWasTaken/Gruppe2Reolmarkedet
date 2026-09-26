using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        //Ingen startside er valgt endnu - når vi oprettet en startside, kan vi rette til, at den ikke kan være null. 
        // ? sat efter ViewModelBase for at indikere at den kan være null.
        private ViewModelBase? _currentViewModel;
        public ViewModelBase? CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel == value)
                {
                    return; 

                    _currentViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        //Når vi har opettet en startside, kan vi fjerne kommenteringen af denne constructor.
        //Går udfra startsiden er HomeViewModel.

        //public MainViewModel()
        //{ 
        //    CurrentViewModel = new HomeViewModel();
        // }


    }
}
