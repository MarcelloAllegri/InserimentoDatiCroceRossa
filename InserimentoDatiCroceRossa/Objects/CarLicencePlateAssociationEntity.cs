using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class CarLicencePlateAssociationEntity : BaseEntity
    {
        public CarLicencePlateAssociationEntity() : base()
        {

        }

        private int m_CarId;

        public int CarId
        {
            get { return m_CarId; }
            set { m_CarId = value; }
        }

        private int m_LicencePlateId;

        public int LicencePlateId
        {
            get { return m_LicencePlateId; }
            set { m_LicencePlateId = value; }
        }

        private DateTime m_AssociationDate;
        public DateTime AssociationDate
        {
            get { return m_AssociationDate; }
            set { m_AssociationDate = value; }
        }

    }
}
