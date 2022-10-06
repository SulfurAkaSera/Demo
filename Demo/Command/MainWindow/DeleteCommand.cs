using Demo.Model;
using Demo.Service;
using Demo.ViewModel;
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
        private MainViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public DeleteCommand(DataService dataService, Car car, MainViewModel viewModel)
        {
            _dataService = dataService;
            _car = car;
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _dataService.Delete(_car);
            _viewModel.SetCars(_dataService.GetCars());
        }
    }
}
