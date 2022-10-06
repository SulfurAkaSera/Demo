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


        public ObservableCollection<Car> Cars { get; set; }
        public Car SelectedCar { get; set; }

        public ICommand AddCommand { get; }
        public ICommand UpdateListCommand { get; }
        public ICommand DeleteCommand { get { return new DeleteCommand(_dataService, SelectedCar, this); } }
        public MainViewModel()
        {
            _dataService = new DataService(true);
            _dataService.CreateTable();
            Cars = new ObservableCollection<Car>();
            AddCommand = new AddCommand();
            UpdateListCommand = new UpdateListCommand(_dataService, this);
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

        public void SetCars(ObservableCollection<Car> cars)
        {
            Cars.Clear();
            foreach (var car in cars)
            {
                Cars.Add(car);
            }
        }
    }
}
