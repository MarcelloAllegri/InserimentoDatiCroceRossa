using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class AutoEntity : BaseEntity
    {
        public AutoEntity() : base()
        {

        }

        private string m_CarName;

        public string CarName
        {
            get { return m_CarName; }
            set { m_CarName = value; }
        }

    }
}
