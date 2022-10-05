using System.Collections.ObjectModel;
using System.Windows.Input;
using Demo.Abstraction;
using Demo.Command.MainWindow;
using Demo.Model;
using Demo.Service;

namespace Demo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private DataService _dataService;
        private Car _car;

        public ObservableCollection<Car> Cars;
        public Car SelectedCar { get { return _car; } set { if (value != null) _car = value; OnPropertyChanged("SelectedCar"); } }

        public ICommand AddCommand => new AddCommand();
        public ICommand UpdateListCommand => new UpdateListCommand(_dataService);
        public ICommand DeleteCommand => new DeleteCommand(_dataService, SelectedCar);
        public MainViewModel()
        {
            Cars = new ObservableCollection<Car>();
            _dataService = new DataService(true);
            _dataService.CreateTable();
            Init();
        }

        private void Init()
        {
            var cars = _dataService.GetCars();
            foreach(var car in cars)
            {
                Cars.Add(car);
            }
        }
    }
}
