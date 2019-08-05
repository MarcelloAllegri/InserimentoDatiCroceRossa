using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class BaseEntity : INotifyPropertyChanged
    {
        public BaseEntity()
        {
            Id = -1;
        }

        private int m_Id;
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get { return m_Id; }
            set
            {
                m_Id = value;
                NotifyPropertyChanged(nameof(Id));
            }
        }

        protected void NotifyPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
