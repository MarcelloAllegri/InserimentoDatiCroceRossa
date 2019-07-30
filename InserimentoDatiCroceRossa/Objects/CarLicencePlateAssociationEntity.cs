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
            set
            {
                m_CarId = value;
                this.CarName = new DbServiceObjects.AutoService().GetAllCars().FirstOrDefault(x => x.Id == value).CarName;
            }
        }

        private int m_LicencePlateId;

        public int LicencePlateId
        {
            get { return m_LicencePlateId; }
            set
            {
                m_LicencePlateId = value;
                this.LicencePlate = new DbServiceObjects.LicencePlateService().GetAllLicencePlates().FirstOrDefault(x => x.Id == value).Targa;
            }
        }

        private bool m_IsEnabled;
        public bool IsEnabled
        {
            get { return m_IsEnabled; }
            set { m_IsEnabled = value; }
        }

        private string m_CarName;

        public string CarName
        {
            get { return m_CarName; }
            set { m_CarName = value; }
        }

        private string m_LicencePlate;

        public string LicencePlate
        {
            get { return m_LicencePlate; }
            set { m_LicencePlate = value; }
        }


        private List<AutoEntity> m_CarList;

        public List<AutoEntity> CarList
        {
            get { return m_CarList; }
            set
            {
                m_CarList = value;
                OnPropertyChanged(nameof(CarList));
            }
        }

        private List<LicencePlateEntity> m_LicencePlateList;

        public List<LicencePlateEntity> LicencePlateList
        {
            get { return m_LicencePlateList; }
            set
            {
                m_LicencePlateList = value;
                OnPropertyChanged(nameof(LicencePlateList));
            }
        }

    }
}
