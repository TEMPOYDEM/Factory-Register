using Factory_Register.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Factory_Register.ViewModels
{
    //Логика работы страницы входа
    //Лучше спросите меня, чтобы что-то поправить
    //Очинь больна
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public async void OnSubmit()
        {
            if (email != "karavashkinav.20@edu.ystu.ru" || password != "developer") //   || (email != "chistyakovmyu.20@edu.ystu.ru" || password != "developer")|| (email != "smirnovva2.20@edu.ystu.ru" || password != "developer")|| (email != "zhiltsovaa.12@edu.ystu.ru" || password != "tester")
            {
                
                if (email != "chistyakovmyu.20@edu.ystu.ru" || password != "developer") 
                { 
                    if (email != "smirnovva2.20@edu.ystu.ru" || password != "developer")
                    {
                        if (email != "zhiltsovaa.12@edu.ystu.ru" || password != "tester")
                        {
                            DisplayInvalidLoginPrompt();
                        }
                    }
                }
            }
            
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
        }
    }
}

