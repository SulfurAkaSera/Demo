using Demo.Model;
using Demo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo.Command.AddWindow
{
    public class AddCommand : ICommand
    {
        private DataService _dataService;

        public event EventHandler CanExecuteChanged;

        private Car _car; 
        public AddCommand(Car car, DataService dataService)
        {
            _car = car;
            _dataService = dataService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _dataService.Insert(_car);
        }
    }
}
