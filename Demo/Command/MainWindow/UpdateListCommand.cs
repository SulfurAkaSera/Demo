using Demo.Service;
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
        public event EventHandler CanExecuteChanged;
        private DataService _dataService;

        public UpdateListCommand(DataService dataService)
        {
            _dataService = dataService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _dataService.GetData();
        }
    }
}
