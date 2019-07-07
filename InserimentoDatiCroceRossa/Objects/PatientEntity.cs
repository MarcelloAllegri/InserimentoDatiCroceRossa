using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class PatientEntity : BaseEntity
    {
        public PatientEntity() : base()
        {

        }

        private string m_FiscalCode;

        public string FiscalCode
        {
            get { return m_FiscalCode; }
            set { m_FiscalCode = value; }
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

        private bool? m_Sex;

        public bool? Sex
        {
            get { return m_Sex; }
            set { m_Sex = value; }
        }

        private DateTime m_Birthday;

        public DateTime Bday
        {
            get { return m_Birthday; }
            set { m_Birthday = value; }
        }

    }
}
