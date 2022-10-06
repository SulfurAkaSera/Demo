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
    public class UpdateListCommand : ICommand
    {
        private DataService _dataService;
        private MainViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public UpdateListCommand(DataService dataService, MainViewModel viewModel)
        {
            _viewModel = viewModel;
            _dataService = dataService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.SetCars(_dataService.GetCars());
        }
    }
}
