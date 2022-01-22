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
        private int id;
        private int itemId;
        private string name;
        private string description;
        private string location;
        private DateTime date;
        private int price;

        public ItemDetailViewModel()
        {
            Title = "Просмотр";
            SaveItemCommand = new Command(OnSaveItem);
            DeleteItemCommand = new Command(OnDeleteItem);

        }

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
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
        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        public int Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }




        public async void LoadItemId(int ItemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(ItemId);
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                Location = item.Location;
                Date = item.Date;
                Price = item.Price;
            }
            catch (Exception)
            {
                Debug.WriteLine("Ошибка загрузки товара");
            }
        }
        public Command DeleteItemCommand { get; }
        public Command SaveItemCommand { get; }
        private async void OnDeleteItem(object obj)
        {

            await DataStore.DeleteItemAsync(ItemId);
            await Shell.Current.GoToAsync("..");
            await App.Current.MainPage.DisplayAlert("Удаление завершено", "Вы можете покинуть страницу", "OK");

        }
        private async void OnSaveItem(object obj)
        {
            try
            {
                Item updatedItem = new Item()
                {
                    Id = Id,
                    Name = Name,
                    Description = Description,
                    Location = Location,
                    Date = Date,
                    Price = Price,
                };
                await DataStore.UpdateItemAsync(updatedItem);

                await Shell.Current.GoToAsync("..");
                await App.Current.MainPage.DisplayAlert("Сохранение завершено", "Вы можете покинуть страницу", "OK");
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Не удаётся считать данные", "OK");
            }

        }
    }
}
