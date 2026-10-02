using Reolmarkedet.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.UI.Utilities
{
    public class NavigationService
    {
        private readonly MainViewModel _mainViewModel;

        public NavigationService(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        //Methoden bytter active viewmodel til generisk view model. 
        //Opretter en ny ViewModel af typen T og sætter den som CurrentViewModel i MainViewModel.
        //T skal arve fra ViewModelBase og have en parameterløs constructor (new()).
        public void NavigateTo<T>() where T : ViewModelBase, new()
        {
            var viewModel = new T();
            _mainViewModel.CurrentViewModel = viewModel;
        }

        //Til en ViewModel, der allerede er oprettet. 
        public void NavigateTo(ViewModelBase viewModel)
        {
            _mainViewModel.CurrentViewModel = viewModel;
        }
    }
}
