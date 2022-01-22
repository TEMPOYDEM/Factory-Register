using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Factory_Register.Services;
using Xamarin.Forms;
using System.IO;
using Factory_Register.Models;
using SQLite;

[assembly: Dependency(typeof(Factory_Register.Services.SQLConn))]
namespace Factory_Register.Services
{

    public class DataService
    {
        private string Name;
        private string Location;
        private string Date;
        private string Price;
        SQLite.SQLiteConnection _sqlConnect;
        public DataService()
        {
            _sqlConnect = DependencyService.Get<SQLConn>().DatabaseService();

            _sqlConnect.CreateTable<Item>();
        }
        public SQLite.TableQuery<Item> GetSearchResults(string queryString)
        {
            var table = _sqlConnect.Table<Item>();
            var normalizedQuery = queryString?.ToLower() ?? "";
            return table.Where(x => x.Name == Name && x.Location == Location);
        }
    }
}
