using Main.Model;
using Main.Utils;
using MaterialDesignThemes.Wpf;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Main.ViewModels
{
    public class BotViewModel : BindableBase
    {       
        public DelegateCommand<Account> StartBotCommand { get; private set; }
        public DelegateCommand<Account> AuthCommand { get; private set; }
        public BotViewModel()
        {

            StartBotCommand = new DelegateCommand<Account>((s) => StartBotExecute(s));
            AuthCommand = new DelegateCommand<Account>((s) => AuthExecute(s));
        }

        /// <summary>
        /// Когда сценарий отработает надо закрыть окно. Дать возможность закрывать окно. 
        /// </summary>
        /// <param name="account"></param>
        private  void StartBotExecute(Account account)
        {
            string selectedScenario = ((TextBlock)account.SelectedStatus.Content).Text;
            CancellationTokenSource source = new CancellationTokenSource();

            Task.Factory.StartNew(() =>
            {
                string profileDir = account.Name;
                //string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Path.Combine(@"Mozilla\Firefox\Profiles", profileDir));
                var profileManager = new FirefoxProfileManager();

                ChromeOptions options = new ChromeOptions();
                options.AddArgument("user-data-dir=" + account.ProfilePath);
                options.AddArguments("--disable-notifications");

                ChromeDriver driver = new ChromeDriver(options);

                //bool isAuth = Browser.CheckAuth(driver);
                //if (!isAuth)
                //{

                //}
                //else
                //{
                //    MessageBox.Show("Авторизация выполена успешно");
                //}

                Browser.Auth(driver, account);
                switch (selectedScenario)
                {
                    case "Add Fun Page":
                         AddPageInAdvertCabinet(account);
                        break;

                    case "Create Fun Page":
                        CreatePage(driver, account);
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                        break;
                }

            }, source.Token);
        }

        private void AuthExecute(Account account)
        {
            CancellationTokenSource source = new CancellationTokenSource();

            Task.Factory.StartNew(() =>
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("user-data-dir=" + account.ProfilePath);
                options.AddArguments("--disable-notifications");

                ChromeDriver driver = new ChromeDriver(options);

                Browser.Auth(driver, account);

                driver.Quit();

            }, source.Token);
        }

        private void CreatePageCommand(Account account)
        {
            
        }

        private void CreatePage(IWebDriver driver, Account account)
        {
            Browser.CreatePage(driver, account);
        }

        private void AddPageInAdvertCabinet(Account account)
        {
            
        }

        private void SerializeAccount(List<Account> listAccount)
        {
            /*
            NetDataContractSerializer serializer = new NetDataContractSerializer();
            using (FileStream fs = File.Create("accaunt.xml"))
            {
                serializer.Serialize(fs, listAccount);
            }
            */
        }
    }
}
