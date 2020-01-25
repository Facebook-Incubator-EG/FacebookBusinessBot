using Main.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Data;
using OpenQA.Selenium.Firefox;


namespace Main.ViewModels
{
    public class AccountManagerViewModel : BindableBase
    {
        public static CollectionViewSource viewAccounts = new CollectionViewSource();
        public static ObservableCollection<Account> accounts { get; set; }

        public DelegateCommand<Account> AddAccountCommand { get; private set; }
        public DelegateCommand<Account> DeleteCommand { get; private set; }

        //public List<string> scenariosList { get; set; }
        private string _nameProfileEdit;
        public string NameProfileEdit
        {
            get { return _nameProfileEdit; }
            set
            {
                _nameProfileEdit = value;
                RaisePropertyChanged("NameProfileEdit");
            }
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                RaisePropertyChanged("Login");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        public AccountManagerViewModel()
        {
            accounts = new ObservableCollection<Account>();

            AddAccountCommand = new DelegateCommand<Account>((s) => AddAccountExecute(s));
            DeleteCommand = new DelegateCommand<Account>((s) => DeleteAccountExecute(s));

            IDataService _dataService = new DataService();

            _dataService.GetAccounts(
                (data, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    accounts = new ObservableCollection<Account>(data.Select(b => new Account
                    {
                        Name = b.Name,
                        Login = b.Login,
                        Password = b.Password,
                        CookiePath = b.CookiePath,
                        ProfilePath = b.ProfilePath,
                        UseProxy = b.UseProxy,
                        ProxyHost = b.ProxyHost,
                        ProxyPort = b.ProxyPort,
                        LastUpdate = b.LastUpdate
                    }));

                    viewAccounts.Source = accounts;
                });
        }

        private void AddAccountExecute(Account s)
        {
            string directoryCookies = System.IO.Directory.GetCurrentDirectory() + @"\data\" + NameProfileEdit;
            string pathToProfileChrome = Environment.ExpandEnvironmentVariables("%APPDATA%") + @"\Local\Google\Chrome\" + NameProfileEdit;

            if (!Directory.Exists(directoryCookies))
                Directory.CreateDirectory(directoryCookies);

            if (!Directory.Exists(pathToProfileChrome))
            {
                Directory.CreateDirectory(pathToProfileChrome);
            }

            File.Create(directoryCookies + @"\cookies");

            accounts.Add(new Account { Name = NameProfileEdit, Login = Login, Password = Password, CookiePath = directoryCookies + @"\cookies", ProfilePath = pathToProfileChrome, });
            viewAccounts.Source = accounts;

            SerializeAccount(accounts.ToList());
        }

        private void DeleteAccountExecute(Account s)
        {
            accounts.Remove(s);
            SerializeAccount(accounts.ToList());
            if (Directory.Exists(@"data\" + s.Name))
            {
                Directory.Delete(@"data\" + s.Name, true);
            }
            if (Directory.Exists(s.ProfilePath))
            {
                Directory.Delete(s.ProfilePath, true);
            }
        }

        private void SerializeAccount(List<Account> listAccount)
        {            
            NetDataContractSerializer serializer = new NetDataContractSerializer();
            using (FileStream fs = File.Create("accaunts.xml"))
            {
                serializer.Serialize(fs, listAccount);
            }            
        }
    }
}
