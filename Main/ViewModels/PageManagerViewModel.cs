using Main.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Data;

namespace Main.ViewModels
{
    public class PageManagerViewModel : BindableBase
    {

        private Page _pageForm;
        public Page pageForm
        {
            get { return _pageForm; }
            set
            {
                _pageForm = value;
                RaisePropertyChanged("pageForm");
            }
        }

        public static CollectionViewSource viewPages = new CollectionViewSource();
        public static ObservableCollection<Page> pages { get; set; }

        public DelegateCommand AddPageCommand { get; private set; }
        public DelegateCommand<Page> DeleteCommand { get; private set; }

        public PageManagerViewModel()
        {
            IDataService _dataService = new DataService();

            _dataService.GetPages(
                (data, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    pages = new ObservableCollection<Page>(data.Select(b => b));


                    viewPages.Source = pages;
                });

            pages = new ObservableCollection<Page>();
            pageForm = new Page();

            AddPageCommand = new DelegateCommand(AddPageExecute);
            DeleteCommand = new DelegateCommand<Page>((s) => DeletePageExecute(s));
        }

        private void AddPageExecute()
        {
            pages.Add(new Page { 

                PageName = pageForm.PageName, 
                PageCategory = pageForm.PageCategory,
                PageCity = pageForm.PageCity,
                PageStreet = pageForm.PageStreet,
                PageIndex = pageForm.PageIndex,
                PagePhone = pageForm.PagePhone,

            });

            viewPages.Source = pages;
            SerializeAccount(pages.ToList());

            pageForm = new Page();
        }

        private void DeletePageExecute(Page p)
        {
            pages.Remove(p);
            SerializeAccount(pages.ToList());
        }

        private void SerializeAccount(List<Page> listPage)
        {
            NetDataContractSerializer serializer = new NetDataContractSerializer();
            using (FileStream fs = File.Create("pages.xml"))
            {
                serializer.Serialize(fs, listPage);
            }
        }
    }
}
