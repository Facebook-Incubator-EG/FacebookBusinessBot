using Main.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Main.Utils
{
    public static class Browser
    {
        public static void Auth(IWebDriver driver, Account account)
        {

            driver.Navigate().GoToUrl("https://business.facebook.com/login/?next=https%3A%2F%2Fbusiness.facebook.com%2F");

            try
            {
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id='email']")).SendKeys(account.Login);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id='pass']")).SendKeys(account.Password);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id='loginbutton']")).Click();
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException)
            {

            } 
        }

        /// <summary>
        /// Метод проверяет авторизацию в личном кабинете.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static bool CheckAuth(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://business.facebook.com/");
            try
            {
                driver.FindElement(By.XPath("//*[@class='img']"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }         
        }
        /// <summary>
        /// Метод добавляет страницы которыми управляю
        /// </summary>
        /// <param name="driver"></param>
        public static void addFunPage(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath("//*[text()='Добавить Страницу']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[text()='Добавить Страницу']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id='pass']")).SendKeys("https://www.facebook.com/animegirls.sex");
                Thread.Sleep(2000);

                //return true;
            }
            catch (NoSuchElementException)
            {
                //return false;
            }
        }

        public static void CreatePage(IWebDriver driver, Account account)
        {  
            try
            {
                driver.Navigate().GoToUrl("https://www.facebook.com/pages/?category=your_pages");
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[text()='Создать Страницу']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[text()='Начать']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@data-testid='BUSINESS_SUPERCATEGORYSelectButton']/div/div[text()='Начать']")).Click();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Это пока не надо
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="path"></param>
        private static void saveCookies(IWebDriver driver, string path)
        {
            IReadOnlyCollection<Cookie> cookes = driver.Manage().Cookies.AllCookies;

            NetDataContractSerializer serializer = new NetDataContractSerializer();
            using (FileStream fs = File.Create("cookies"))
            {
                serializer.Serialize(fs, cookes);
            }
        }
    }
}
