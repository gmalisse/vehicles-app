using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SQLite;
using VehiclesApp.Models;

namespace VehiclesApp.Helpers
{
    public class BrandSQLiteHelper
    {
        readonly SQLiteAsyncConnection _connection;

        public BrandSQLiteHelper(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Brand>().Wait();
        }

        public Task<int> Insert(Brand brand)
        {
            return _connection.InsertAsync(brand);
        }

        public Task<List<Brand>> Update(Brand brand)
        {
            string sql = "UPDATE Brand SET Observation=?, Name=? WHERE Id=?";
            return _connection.QueryAsync<Brand>(sql, brand.Observation, brand.Name, brand.Id);
        }

        public Task<List<Brand>> Delete(int Id)
        {
            string sql = "DELETE FROM Brand WHERE Id=?";
            return _connection.QueryAsync<Brand>(sql, Id);
        }

        public Task<List<Brand>> GetAll()
        {
            return _connection.Table<Brand>().ToListAsync();
        }

        public Task<List<Brand>> Search(string m)
        {
            string sql = "SELECT * FROM Brand WHERE Name LIKE '%" + m + "%'";
            return _connection.QueryAsync<Brand>(sql, m);
        }
    }
}
