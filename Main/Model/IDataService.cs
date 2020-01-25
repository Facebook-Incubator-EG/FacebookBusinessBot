using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Model
{
    interface IDataService
    {
        void GetAccounts(Action<List<Account>, Exception> callback);
        void GetPages(Action<List<Page>, Exception> callback);
    }
}
