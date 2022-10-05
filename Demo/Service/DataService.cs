using Demo.Abstraction;
using Demo.Model;
using Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
    public class DataService
    {
        private ObservableCollection<Car> _cars;
        private SqlConnection _connection;

        public delegate void UpdateData();
        public event UpdateData Update;

        public DataService(bool updateData)
        {
            if(updateData)
            {
                _cars = new ObservableCollection<Car>();
                _connection = new SqlConnection(@"Data source=BEST-KOMP\SQLEXPRESS;Initial catalog=DemoDB;Integrated security=true");
                Update += GetData;
                Update.Invoke();
            }
            else
            {
                _cars = new ObservableCollection<Car>();
                _connection = new SqlConnection(@"Data source=BEST-KOMP\SQLEXPRESS;Initial catalog=DemoDB;Integrated security=true");
            }
        }

        public void CreateTable()
        {
            _connection.Open();
            SqlCommand command = new SqlCommand(@"SELECT OBJECT_ID (N'dbo.Cars', N'U')", _connection);
            bool isNotCreated = true;
            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                isNotCreated = reader.IsDBNull(0);
            }
            if (isNotCreated)
            {
                SqlCommand createCmd = new SqlCommand
                    (
                        "CREATE TABLE dbo.Cars(" +
                        "Id DECIMAL(6, 0) IDENTITY(1, 1) NOT NULL," +
                        "Brand NVARCHAR(25) NOT NULL," +
                        "Model NVARCHAR(25) NOT NULL," +
                        "Engine NVARCHAR(25) NOT NULL," +
                        "Transmission NVARCHAR(25) NOT NULL," +
                        "Body NVARCHAR(25) NOT NULL," +
                        "Cost BIGINT NOT NULL," +
                        "CONSTRAINT PK_Card_Id PRIMARY KEY CLUSTERED(Id),);",
                        _connection
                    );
                createCmd.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public void GetData()
        {
            _connection.Open();
            if (_cars.Count != 0)
                _cars.Clear();
            SqlCommand readCmd = new SqlCommand(@"SELECT * FROM [Cars]", _connection);
            using (var reader = readCmd.ExecuteReader())
            {
                while (reader.Read())
                    _cars.Add(new Car().GetData(reader));
            }
            _connection.Close();
        }

        public void Insert(Car car)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand(car.GetInsertString(), _connection);
            command.Parameters.AddRange(car.GetParameters().ToArray());
            command.ExecuteNonQuery();
            Update.Invoke();
            _connection.Close();
        }

        public void Delete(Car car)
        {
            _connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM [Cars] WHERE Id=@Id", _connection);
            command.Parameters.Add(new SqlParameter("@Id", car.Id));
            command.ExecuteNonQuery();
            Update.Invoke();
            _connection.Close();
        }

        public ObservableCollection<Car> GetCars() => _cars;

        public void ConnectionDispose()
        {
            _connection.Dispose();
        }
    }
}
