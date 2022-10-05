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
        private string _brand;
        private string _model;
        private string _engine;
        private string _transmission;
        private string _body;
        private long _cost;
        private DataService _dataService;

        public string Brand { get { return _brand; } set { if (value != null) _brand = value; OnPropertyChanged("Brand"); } }
        public string Model { get { return _model; } set { if (value != null) _model = value; OnPropertyChanged("Model"); } }
        public string Engine { get { return _engine; } set { if (value != null) _engine = value; OnPropertyChanged("Engine"); } }
        public string Transmission { get { return _transmission; } set { if (value != null) _transmission = value; OnPropertyChanged("Transmission"); } } 
        public string Body { get { return _body; } set { if (value != null) _body = value; OnPropertyChanged("Body"); } }   
        public long Cost { get { return _cost; } set { if (value != null) _cost = value; OnPropertyChanged("Cost"); } }

        public ICommand AddCommand => new AddCommand(new Car {Brand = _brand, Model = _model, Engine = _engine, Transmission = _transmission, Body = _body, Cost = _cost }, _dataService);

        public AddViewModel()
        {
            _dataService = new DataService(true);
        }
    }
}
