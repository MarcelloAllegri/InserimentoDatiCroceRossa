using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public static class GlobalInfo
    {
        private static UserEntity m_LoggedUser;
        private static bool m_IsUserAdmin;

        public static UserEntity LoggedUser
        {
            get { return m_LoggedUser; }
            set { m_LoggedUser = value;
                if (m_LoggedUser.UserType != 'A')
                    IsUserAdmin = false;
                else IsUserAdmin = true;
            }
        }


        public static bool IsUserAdmin
        {
            get { return m_IsUserAdmin; }
            set { m_IsUserAdmin = value; }
        }
    }
}
