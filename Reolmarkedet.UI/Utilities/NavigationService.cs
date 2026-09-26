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

        //Til en ViewModel, der allerede er oprettet. 
        public void NavigateTo(ViewModelBase viewModel)
        {
            _mainViewModel.CurrentViewModel = viewModel;
        }
    }
}
