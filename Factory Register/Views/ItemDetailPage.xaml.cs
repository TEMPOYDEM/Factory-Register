using Factory_Register.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Factory_Register.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}