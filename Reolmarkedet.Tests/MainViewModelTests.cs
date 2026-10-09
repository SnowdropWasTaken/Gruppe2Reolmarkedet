using Reolmarkedet.UI.ViewModels;

namespace Reolmarkedet.Tests;

[TestClass]
public class MainViewModelTests
{
    private class TestViewModel : ViewModelBase
    {
    }

    [TestMethod]
    //Tester, om MainViewModel gemmer den ViewModel, der tildeles til CurrentViewModel. 
    public void CurrentViewModel_WhenAssigned_StoresViewModel()
    {
        //Arrange
        var mainViewModel = new MainViewModel();
        var expectedViewModel = new TestViewModel();

        //Act
        mainViewModel.CurrentViewModel = expectedViewModel;

        //Assert 
        Assert.AreSame(
                expectedViewModel,
                mainViewModel.CurrentViewModel,
                "CurrentViewModel should store the assigned view model.");
    }
}
