using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Main.Model
{
    public class Account
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

        /// <summary>
        /// Статус 
        /// </summary>
        private ComboBoxItem _selectedStatus;
        public ComboBoxItem SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                if (value != null)
                {
                    _selectedStatus = value;
                    OnPropertyChanged("SelectedStatus");
                }
            }
        }

        private bool m_useProxy;
        [DataMember]
        public bool UseProxy
        {
            get { return m_useProxy; }
            set
            {
                m_useProxy = value;
                OnPropertyChanged("UseProxy");
            }
        }

        private string _name;
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _login;
        [DataMember]
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _password;
        [DataMember]
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private string _cookiePath;
        [DataMember]
        public string CookiePath
        {
            get { return _cookiePath; }
            set
            {
                _cookiePath = value;
                OnPropertyChanged("CookiePath");
            }
        }

        private string _profilePath;
        [DataMember]
        public string ProfilePath
        {
            get { return _profilePath; }
            set
            {
                _profilePath = value;
                OnPropertyChanged("ProfilePath");
            }
        }

        private string _proxyHost;
        [DataMember]
        public string ProxyHost
        {
            get { return _proxyHost; }
            set
            {
                _proxyHost = value;
                OnPropertyChanged("ProxyHost");
            }
        }

        private int _proxyPort;
        [DataMember]
        public int ProxyPort
        {
            get { return _proxyPort; }
            set
            {
                _proxyPort = value;
                OnPropertyChanged("ProxyPort");
            }
        }

        private DateTime _lastUpdate;
        [DataMember]
        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set
            {
                _lastUpdate = value;
                OnPropertyChanged("LastUpdate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
