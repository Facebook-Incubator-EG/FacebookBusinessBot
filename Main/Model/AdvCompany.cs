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
    class AdvCompany
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
}
