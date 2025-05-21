using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using VehiclesApp.Models;

namespace VehiclesApp.Helpers
{
    public class VehicleSQLiteHelper
    {
        readonly SQLiteAsyncConnection _connection;

        public VehicleSQLiteHelper(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Vehicle>().Wait();
        }

        public Task<int> Insert(Vehicle vehicle)
        {
            return _connection.InsertAsync(vehicle);
        }

        public Task<List<Vehicle>> Update(Vehicle vehicle)
        {
            string sql = "UPDATE Vehicle SET Observation=?, Name=? WHERE Id=?";
            return _connection.QueryAsync<Vehicle>(sql, vehicle.Observation, vehicle.Name, vehicle.Id);
        }

        public Task<List<Vehicle>> Delete(int Id)
        {
            string sql = "DELETE FROM Vehicle WHERE Id=?";
            return _connection.QueryAsync<Vehicle>(sql, Id);
        }

        public Task<List<Vehicle>> GetAll()
        {
            return _connection.Table<Vehicle>().ToListAsync();
        }

        public Task<List<Vehicle>> Search(string m)
        {
            string sql = "SELECT * FROM Vehicle WHERE Name LIKE '%" + m + "%'";
            return _connection.QueryAsync<Vehicle>(sql, m);
        }
    }
}
