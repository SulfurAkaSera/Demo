using Demo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo.Command.MainWindow
{
    public class AddCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public AddCommand() { }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var addCarWindow = new AddCarWindow();
            addCarWindow.Show();
        }
    }
}
