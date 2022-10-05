using System.Collections.Generic;
using System.Data.SqlClient;

namespace Demo.Model
{
    public class Car
    {
        public decimal Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string Body { get; set; }
        public long Cost { get; set; }

        public List<SqlParameter> GetParameters()
        {
            List<SqlParameter> sqlParameter = new List<SqlParameter>()
            {
                new SqlParameter(@"Brand", Brand),
                new SqlParameter(@"Model", Model),
                new SqlParameter(@"Engine", Engine),
                new SqlParameter(@"Transmission", Transmission),
                new SqlParameter(@"Body", Body),
                new SqlParameter(@"Cost", Cost),
            };
            return sqlParameter;
        }

        public Car GetData(SqlDataReader reader)
        {
            Id = reader.GetDecimal(0);
            Brand = reader.GetString(1);
            Model = reader.GetString(2);
            Engine = reader.GetString(3);
            Transmission = reader.GetString(4);
            Body = reader.GetString(5);
            Cost = reader.GetInt64(6);
            return this;
        }

        public string GetInsertString()
        {
            return "Insert INTO Cars" +
                   " (Brand, Model, Engine, Transmission, Body, Cost)" +
                   " VALUES (@Brand, @Model, @Engine, @Transmission, @Body, @Cost)";
        }
    }
}
