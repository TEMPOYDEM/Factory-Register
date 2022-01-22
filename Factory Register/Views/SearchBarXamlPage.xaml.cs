using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Factory_Register.Services;
using Xamarin.Forms;

namespace Factory_Register.Views
{

    public partial class SearchBarXamlPage : ContentPage
    {
        public SearchBarXamlPage()
        {
            InitializeComponent();
            searchResults.ItemsSource = Models.Item;
        }

        void OnSearchButtonPressed(object sender, EventArgs e)
        {
            searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);
        }
    }
}
