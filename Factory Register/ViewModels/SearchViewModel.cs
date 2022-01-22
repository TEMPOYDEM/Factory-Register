using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Factory_Register.Models;
using Factory_Register.Services;
using SQLite;
using Xamarin.Forms;

namespace Factory_Register.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        SQLite.SQLiteConnection _sq;
        public event PropertyChangedEventHandler PropertyChanged;

        public SearchViewModel()
        {
            _sq = DependencyService.Get<SQLConn>().DatabaseService();
            _sq.CreateTable<Item>();
        }
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            var ds = new DataService();
            SearchResults = ds.GetSearchResults(query);
            return  Task.FromResult(_sq.Get<Item>(id));
        });
        _sq = DependencyService.Get<SQLConn>().DatabaseService();
        Table<> searchResults = Item Table<Item>;
        public List<string> SearchResults
        {
            get
            {
                return searchResults;
            }
            set
            {
                searchResults = value;
                NotifyPropertyChanged();
            }
        }
    }
}
