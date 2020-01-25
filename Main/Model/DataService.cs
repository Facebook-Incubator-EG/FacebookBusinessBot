using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Main.Model
{
    public class DataService : IDataService
    {
        public void GetAccounts(Action<List<Account>, Exception> callback)
        {
            NetDataContractSerializer serializer = new NetDataContractSerializer();

            List<Account> accounts = new List<Account>();
            if (File.Exists("accaunts.xml"))
            {
                using (FileStream fs = File.OpenRead("accaunts.xml"))
                {
                    accounts = (List<Account>)serializer.Deserialize(fs);
                }
            }

            callback(accounts, null);
        }

        public void GetPages(Action<List<Page>, Exception> callback)
        {
            NetDataContractSerializer serializer = new NetDataContractSerializer();

            List<Page> pages = new List<Page>();
            if (File.Exists("pages.xml"))
            {
                using (FileStream fs = File.OpenRead("pages.xml"))
                {
                    pages = (List<Page>)serializer.Deserialize(fs);
                }
            }

            callback(pages, null);
        }
    }
}
