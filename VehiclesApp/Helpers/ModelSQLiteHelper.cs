using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using VehiclesApp.Models;

namespace VehiclesApp.Helpers
{
    public class ModelSQLiteHelper
    {
        readonly SQLiteAsyncConnection _connection;

        public ModelSQLiteHelper(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Model>().Wait();
        }

        public Task<int> Insert(Model model)
        {
            return _connection.InsertAsync(model);
        }

        public Task<List<Model>> Update(Model model)
        {
            string sql = "UPDATE Model SET Observation=?, Name=? WHERE Id=?";
            return _connection.QueryAsync<Model>(sql, model.Observation, model.Name, model.Id);
        }

        public Task<List<Model>> Delete(int Id)
        {
            string sql = "DELETE FROM Model WHERE Id=?";
            return _connection.QueryAsync<Model>(sql, Id);
        }

        public Task<List<Model>> GetAll()
        {
            return _connection.Table<Model>().ToListAsync();
        }

        public Task<List<Model>> Search(string m)
        {
            string sql = "SELECT * FROM Model WHERE Name LIKE '%" + m + "%'";
            return _connection.QueryAsync<Model>(sql, m);
        }
    }
}
