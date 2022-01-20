using Factory_Register.Views;
using Factory_Register.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace Factory_Register.ViewModels
{
    //Логика работы страницы входа
    //Лучше спросите меня, чтобы что-то поправить
    //Очинь больна

    public class User : IEquatable<User>
    {
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            User objAsPart = obj as User;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return Id;
        }

        public bool Equals(User other)
        {
            if (other == null) return false;
            return (this.Id.Equals(other.Id));
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginViewModel : INotifyPropertyChanged
    {

        public List<User> users = new List<User>();
        public LoginViewModel()
        {

            SubmitCommand = new Command(OnSubmit);
        }

        User Artem = new User()
        {
            Id = 1,
            Email = "karavashkinav.20@edu.ystu.ru",
            Password = "developer",

        };
        User Michail = new User()
        {
            Id = 1,
            Email = "chistyakovmyu.20@edu.ystu.ru",
            Password = "developer",

        };
        User Vadim = new User()
        {
            Id = 1,
            Email = "smirnovva2.20@edu.ystu.ru",
            Password = "developer",

        };
        User AA = new User()
        {
            Id = 1,
            Email = "zhiltsovaa.12@edu.ystu.ru",
            Password = "tester",

        };
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

        public async void OnSubmit()
        {
            users.Add(Artem); users.Add(Michail); users.Add(Vadim); users.Add(AA);
            if (true != users.Exists(x => x.Email == Email))
            {

                DisplayInvalidLoginPrompt();

            }

            else
            {
                users.IndexOf(x => x.Email == Email);
                await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
            }

        }
    }
}

