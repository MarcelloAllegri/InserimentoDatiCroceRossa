using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class AddressEntity : BaseEntity
    {
        public AddressEntity() : base()
        {

        }

        private string m_AddressName;

        public string AddressName
        {
            get { return m_AddressName; }
            set { m_AddressName = value; }
        }

    }
}
