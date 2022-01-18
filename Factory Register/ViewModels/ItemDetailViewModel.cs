using Factory_Register.Models;
using Factory_Register.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Factory_Register.ViewModels
{
    public interface IValueConverter { }
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        public Command DeleteItemCommand { get; }

        private int itemId;
        private string name;
        private string description;
        private string location;
        private string date;
        private int price;
        private int quantity;
        private int totalcost;
        public ItemDetailViewModel()
        {

            DeleteItemCommand = new Command(OnDeleteItem);
        }
        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string Location
        {
            get => location;
            set => SetProperty(ref location, value);
        }
        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        public int Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
        public int Quantity
        {
            get => quantity;
            set => SetProperty(ref quantity, value);
        }
        public int Totalcost
        {
            get => totalcost;
            set => SetProperty(ref totalcost, value);
        }
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        private async void OnDeleteItem(object obj)
        {

            await DataStore.DeleteItemAsync(ItemId);
            await Shell.Current.GoToAsync("..");
            await App.Current.MainPage.DisplayAlert("Удаление завершено", "Вы можете покинуть страницу", "OK");

        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                Location = item.Location;
                Date = item.Date;
                Price = item.Price;
                Quantity = item.Quantity;
                Totalcost = item.Totalcost;
            }
            catch (Exception)
            {
                Debug.WriteLine("Ошибка загрузки товара");
            }
        }
    }
}
