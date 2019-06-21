using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class UserEntity
    {
        public UserEntity()
        {

        }

        public UserEntity(int id, string accountName, string password, char userType)
        {
            this.Id = id;
            this.AccountName = accountName;
            this.Password = password;
            this.UserType = userType;
        }

        private int m_Id;

        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        private string m_AccountName;

        public string AccountName
        {
            get { return m_AccountName; }
            set { m_AccountName = value; }
        }

        private string m_Password;

        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        private char m_UserType;

        public char UserType
        {
            get { return m_UserType; }
            set { m_UserType = value; }
        }


    }
}
