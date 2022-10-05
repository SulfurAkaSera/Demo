using Demo.Model;
using Demo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo.Command.MainWindow
{
    public class DeleteCommand : ICommand
    {
        private DataService _dataService;
        private Car _car;

        public event EventHandler CanExecuteChanged;

        public DeleteCommand(DataService dataService, Car car)
        {
            _dataService = dataService;
            _car = car;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _dataService.Delete(_car);
        }
    }
}
