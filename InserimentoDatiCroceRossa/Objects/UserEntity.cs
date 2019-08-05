using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class UserEntity : BaseEntity
    {
        public UserEntity() : base()
        {

        }

        public UserEntity(int id, string accountName, string password, char userType)
        {
            this.Id = id;
            this.AccountName = accountName;
            this.Password = password;
            this.UserType = userType;
        }       

        private string m_AccountName;

        public string AccountName
        {
            get { return m_AccountName; }
            set
            {
                m_AccountName = value;
                NotifyPropertyChanged(nameof(AccountName));
            }
        }

        private string m_Password;

        public string Password
        {
            get { return m_Password; }
            set
            {
                m_Password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }

        private char m_UserType;

        public char UserType
        {
            get { return m_UserType; }
            set
            {
                m_UserType = value;
                NotifyPropertyChanged(nameof(UserType));
            }
        }


    }
}
