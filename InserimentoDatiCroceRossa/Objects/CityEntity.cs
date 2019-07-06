using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class CityEntity : BaseEntity
    {
        public CityEntity() : base()
        {

        }

        private string m_CityName;

        public string CityName
        {
            get { return m_CityName; }
            set { m_CityName = value; }
        }

    }
}
