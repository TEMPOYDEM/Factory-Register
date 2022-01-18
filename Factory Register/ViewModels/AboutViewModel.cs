using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace Factory_Register.ViewModels
{

    //Модель взаимодействия пользователя со страницей добавления товара
    public class AboutViewModel : VMBase
    {

        public AboutViewModel()
        {
            OpenDocumentation = new Command(async () => await Application.Current.MainPage.DisplayAlert("Документация", "В этой программе можно вести учёт имеющихся средств. По кнопке с тремя полосками можно зайти в меню. В меню есть 3 пункта: Документация, список и выход из программы. По кнопке 'список' можно зайи в базу со всеми средствами. Там можно добавить в базу новые средства.", "OK"));
        }

        public ICommand OpenDocumentation { get; }
    }
}