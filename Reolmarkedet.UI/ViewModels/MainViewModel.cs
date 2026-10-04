using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Reolmarkedet.UI.ViewModels
{
    /// <summary>
    /// MainViewModel er den viewmodel, som holder styr på hvilken viewmodel der skal vises i MainWindow.xaml
    /// Klassen arver fra ViewModelBase, som får agang til funktionaliteten i ViewModelBase.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        //Feltet gemmer den aktive viewmodel, som skal vises i MainWindow.xaml
        //Typen er ViewModelbase, feltet kan indeholde alle viewmodels, som arver fra ViewModelBase
        private ViewModelBase _currentViewModel;

        //Property giver adgang til den aktive ViewModel.
        //Get returner ViewModel som ligger i feltet.
        //Set bliver kørt når der skiftes viewmodel, og sætter feltet til den nye viewmodel,
        //_currentViewModel gemmner den nye viewModel som gemmens i værdien value
        //OnPropertyChanged() giver besked at CurrentViewModel er ændret
        //OnPropertyChanged(nameof(WindowTitle)) giver besked om at UI også skal læse windowTitle igen
        //uden WindowTitle ville titlen på vinduet ikke ændre sig når man skifter viewmodel
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(WindowTitle));

            }
        }

        public string WindowTitle
        {
            get
            {
                return CurrentViewModel switch
                {
                    HomeViewModel => "Home",
                    ShelfOverviewViewModel => "Shelves",
                    LeaseOverviewViewModel => "Leases",
                    TenantViewModel => "Tenants",
                    _ => "Home"
                };
            }
        }

        //Constructor vælger start viewmodel, som er HomeViewModel
        public MainViewModel()
        {
            CurrentViewModel = new HomeViewModel();
        }


    }
}
