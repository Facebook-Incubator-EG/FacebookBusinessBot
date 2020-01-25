using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Main.Model
{
    public class Page
    {
        private bool m_value;
        [DataMember]
        public bool Value
        {
            get { return m_value; }
            set
            {
                m_value = value;
                OnPropertyChanged("Value");
            }
        }

        private string _pageName;
        [DataMember]
        public string PageName
        {
            get { return _pageName; }
            set
            {
                _pageName = value;
                OnPropertyChanged("PageName");
            }
        }

        private string _pageCategory;
        [DataMember]
        public string PageCategory
        {
            get { return _pageCategory; }
            set
            {
                _pageCategory = value;
                OnPropertyChanged("PageCategory");
            }
        }

        //Улица
        private string _pageStreet;
        [DataMember]
        public string PageStreet
        {
            get { return _pageStreet; }
            set
            {
                _pageStreet = value;
                OnPropertyChanged("PageStreet");
            }
        }

        //Город
        private string _pageCity;
        [DataMember]
        public string PageCity
        {
            get { return _pageCity; }
            set
            {
                _pageCity = value;
                OnPropertyChanged("PageCity");
            }
        }

        //Индекс
        private string _pageIndex;
        [DataMember]
        public string PageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex = value;
                OnPropertyChanged("PageIndex");
            }
        }

        //Телефон
        private string _pagePhone;
        [DataMember]
        public string PagePhone
        {
            get { return _pagePhone; }
            set
            {
                _pagePhone = value;
                OnPropertyChanged("PagePhone");
            }
        }

        public void ClearField()
        {
            PageName = "";
            PageCategory = "";
            PageCity = "";
            PageStreet = "";
            PagePhone = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
