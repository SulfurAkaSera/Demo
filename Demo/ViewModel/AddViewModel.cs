using Demo.Abstraction;
using Demo.Command.AddWindow;
using Demo.Model;
using Demo.Service;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        private DataService _dataService;
        
        public Car Car { get; set; }

        public ICommand AddCommand { get; set; }

        public AddViewModel()
        {
            _dataService = new DataService(true);
            Car = new Car();
            AddCommand = new AddCommand(Car, _dataService);
        }
    }
}
