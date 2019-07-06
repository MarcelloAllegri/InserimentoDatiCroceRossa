using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class TargaEntity : BaseEntity
    {
        public TargaEntity() : base()
        {

        }

        private string m_Targa;

        public string Targa
        {
            get { return m_Targa; }
            set { m_Targa = value; }
        }

    }
}
