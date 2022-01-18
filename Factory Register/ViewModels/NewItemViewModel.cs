using Factory_Register.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Factory_Register.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {

        private string name;
        private string description;
        private string location;
        private string date;
        private int price;
        private int quantity;

        public NewItemViewModel()
        {
            Title = "Добавить предмет";
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(description) && !String.IsNullOrWhiteSpace(location) && !String.IsNullOrWhiteSpace(date) && !String.IsNullOrWhiteSpace(Convert.ToString(price)) && !String.IsNullOrWhiteSpace(Convert.ToString(quantity));
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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            if (Price == 0 || Quantity == 0)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Вы не заполнили цену или количество", "OK");

            }
            else
            {
                try
                {
                    Item newItem = new Item()
                    {
                        Name = Name,
                        Description = Description,
                        Location = Location,
                        Date = Date,
                        Price = Price,
                        Quantity = Quantity,
                        Totalcost = Quantity * Price,
                    };
                    await DataStore.AddItemAsync(newItem);
                    await Shell.Current.GoToAsync("..");
                }
                catch
                {
                    await App.Current.MainPage.DisplayAlert("Ошибка", "Не удаётся считать данные данные", "OK");
                }
            }

            // This will pop the current page off the navigation stack

        }
    }
}
