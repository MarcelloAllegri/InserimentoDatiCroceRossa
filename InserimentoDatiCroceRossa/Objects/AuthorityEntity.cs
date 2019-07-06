using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class AuthorityEntity : BaseEntity
    {
        public AuthorityEntity() : base()
        {

        }

        private string m_AuthorityName;

        public string AuthorityName
        {
            get { return m_AuthorityName; }
            set { m_AuthorityName = value; }
        }

    }
}
