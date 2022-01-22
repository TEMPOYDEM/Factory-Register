using Factory_Register.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using SQLite;
using System.IO;

[assembly: Dependency(typeof(Factory_Register.ViewModels.SQLConnect))]
namespace Factory_Register.ViewModels
{
    //Логика работы страницы входа
    //Лучше спросите меня, чтобы что-то поправить
    //Очинь больна
    [Table("Login")]
    public class Users
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    class SQLConnect
    {
        public SQLite.SQLiteConnection DatabaseService()
        {
            string filename = "User.db";
            string documentPath = Xamarin.Essentials.FileSystem.AppDataDirectory;
            string fullPath = Path.Combine(documentPath, filename);
            return new SQLite.SQLiteConnection(fullPath, SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache);
        }
    }
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public bool Valid;
        SQLite.SQLiteConnection _sqlConn;


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
            _sqlConn = DependencyService.Get<SQLConnect>().DatabaseService();
            _sqlConn.CreateTable<Users>();
            if (_sqlConn.Table<Users>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var newUser = new Users();
                newUser.Email = "karavashkinav.20@edu.ystu.ru";
                newUser.Password = "developer";
                _sqlConn.Insert(newUser);
                newUser = new Users();
                newUser.Email = "chistyakovmyu.20@edu.ystu.ru";
                newUser.Password = "developer";
                _sqlConn.Insert(newUser);
                newUser = new Users();
                newUser.Email = "smirnovva2.20@edu.ystu.ru";
                newUser.Password = "developer";
                _sqlConn.Insert(newUser);
                newUser = new Users();
                newUser.Email = "zhiltsovaa.12@edu.ystu.ru";
                newUser.Password = "tester";
                _sqlConn.Insert(newUser);
            }
            SubmitCommand = new Command(OnSubmit);
        }
        public async void Users_check()
        {
 
            var table = _sqlConn.Table<Users>();
            var validator = table.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();

            if (validator != null)
            {
                Valid = true;
            }
            else
            {
                Valid = false;
            }
           
        }
        public async void OnSubmit()
        {
            Users_check();
            if ( Valid == false)
            {
                DisplayInvalidLoginPrompt();
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
            }
        }
    }
}



