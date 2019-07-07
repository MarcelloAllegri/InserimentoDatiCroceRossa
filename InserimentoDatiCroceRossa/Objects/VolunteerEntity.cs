using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class VolunteerEntity : BaseEntity
    {
        public VolunteerEntity() : base()
        {

        }

        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private string m_Surname;

        public string Surname
        {
            get { return m_Surname; }
            set { m_Surname = value; }
        }


    }
}
