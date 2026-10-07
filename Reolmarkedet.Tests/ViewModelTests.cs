using Reolmarkedet.UI.ViewModels;

namespace Reolmarkedet.Tests
{
    [TestClass]
    public class ViewModelTests
    {
        private class TestViewModel : ViewModelBase
        {
            private string _name = "";
            public string Name
            {
                get => _name;
                set
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
            [TestMethod]
            //Tester, om propertyChanged-eventet udløses med det korrekte property-navn, når name ændres. 
            public void PropertyChanged_WhenPropertyChanged_RaisesEvent()
            {
                //Arrange
                var viewModel = new TestViewModel();
                String? ChangedProperty = null;

                viewModel.PropertyChanged += (send, e) =>
                {
                    ChangedProperty = e.PropertyName;
                };

                //Act
                viewModel.Name = "Reol";

                //Assert.
                Assert.AreEqual("Name", ChangedProperty, 
                    "PropertyChanged event should be raised with the correct property name.");
            }
        }
    }

