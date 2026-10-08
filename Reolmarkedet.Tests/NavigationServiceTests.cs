using Reolmarkedet.UI.Utilities;
using Reolmarkedet.UI.ViewModels;

namespace Reolmarkedet.Tests;

[TestClass]
public class NavigationServiceTests
{

    private class TestViewModel : ViewModelBase
    {
    }
    [TestMethod]
    //Tester, om NavigationService opretter en ny instans af den valgte viewModel-type
    //og sætter den som CurrentViewModel
    public void NavigateTo_ViewModels_SetsCurrentViewModel()
    {
        //Arrange
        var mainViewModel = new MainViewModel();
        var navigationService = new NavigationService(mainViewModel);

        //Act
        navigationService.NavigateTo<TestViewModel>();

        //Assert
        Assert.IsInstanceOfType(
            mainViewModel.CurrentViewModel,
            typeof(TestViewModel),
            "CurrentViewModel should be an instance of TestViewModel after navigation.");

    }

    [TestMethod]
    //Tester om NavigationService sætter CurrentViewModel til den eksisterende viewModel, 
    //der sendes til NavigateTo()
    public void Navigateto_ExistingViewModel_SetsCurrentViewModel()
    {
        //Arrange
        var mainViewModel = new MainViewModel();
        var navigationService = new NavigationService(mainViewModel);
        var expectedViewModel = new TestViewModel();

        //Act
        navigationService.NavigateTo(expectedViewModel);

        //Assert
        Assert.AreSame(
            expectedViewModel,
            mainViewModel.CurrentViewModel,
            "currentviewmodel should be set to the expected viewmodel after navigation.");

    }
}