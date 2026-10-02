using Reolmarkedet.UI.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;
using Reolmarkedet.UI.Utilities;


namespace Reolmarkedet.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static MainViewModel _mainViewModel = new MainViewModel();

        //NavigationService bruger den samme MainViewModel som MainWindow. 
        public static NavigationService _navigationService = new NavigationService(_mainViewModel);


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            
            
            
            //opretter nye Window
            var mainWindow = new MainWindow()
            {
                //Sætter DataContext af et vindue til viewModelBase
                DataContext = _mainViewModel
            };

            //Åbner et nyt vindue
            mainWindow.Show(); 
        }
    }
}

