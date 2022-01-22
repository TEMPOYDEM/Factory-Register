using Factory_Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using SQLite;
using System.IO;
[assembly: Dependency(typeof(Factory_Register.Services.SQLConn))]
namespace Factory_Register.Services
{
    class SQLConn
    {
        public SQLite.SQLiteConnection DatabaseService()
        {
                string filename = "Item.db";
                string documentPath = Xamarin.Essentials.FileSystem.AppDataDirectory;
                string fullPath = Path.Combine(documentPath, filename);
                return new SQLite.SQLiteConnection(fullPath, SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache);
        }
    }
    public class MockDataStore : IDataStore<Item>
    {
        SQLite.SQLiteConnection _sqlConn;
        public MockDataStore()
        {
            _sqlConn = DependencyService.Get<SQLConn>().DatabaseService();
            _sqlConn.CreateTable<Item>();
        }
        

        public async Task<bool> AddItemAsync(Item item)
        {
            _sqlConn.Insert(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = _sqlConn.Table<Item>().Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            _sqlConn.Delete(oldItem);
            _sqlConn.Insert(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            _sqlConn.Delete<Item>(id);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(_sqlConn.Get<Item>(id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_sqlConn.Table<Item>());
        }
      /*  public static List<string> GetSearchResults(string queryString)
        {
            var item = new List<Item>();
            var normalizedQuery = queryString?.ToLower() ?? "";
            return item.Where(f => f.ToLowerInvariant().Contains(normalizedQuery)).ToList();
        }*/
    }
}