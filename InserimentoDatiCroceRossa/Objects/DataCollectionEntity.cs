using InserimentoDatiCroceRossa.DbServiceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class DataCollectionEntity : BaseEntity
    {
        public DataCollectionEntity() : base()
        {

        }

        private DateTime m_ServiceDate;

        public DateTime ServiceDate
        {
            get { return m_ServiceDate; }
            set { m_ServiceDate = value; NotifyPropertyChanged(nameof(ServiceDate)); }
        }

        private int m_ServiceFromId;

        public int ServiceFromId
        {
            get { return m_ServiceFromId; }
            set { m_ServiceFromId = value; NotifyPropertyChanged(nameof(ServiceFromId)); }
        }

        private int m_ServiceToId;

        public int ServiceToId
        {
            get { return m_ServiceToId; }
            set { m_ServiceToId = value; NotifyPropertyChanged(nameof(ServiceToId)); }
        }

        private int m_ServiceType;

        public int ServiceType
        {
            get { return m_ServiceType; }
            set { m_ServiceType = value; NotifyPropertyChanged(nameof(ServiceType)); }
        }

        private int m_PatientId;

        public int PatientId
        {
            get { return m_PatientId; }
            set { m_PatientId = value; NotifyPropertyChanged(nameof(PatientId)); }
        }

        private string m_AddressValue;

        public string AddressValue
        {
            get { return m_AddressValue; }
            set { m_AddressValue = value; NotifyPropertyChanged(nameof(AddressValue)); }
        }

        
        private string m_PlaceValue;

        public string PlaceValue
        {
            get { return m_PlaceValue; }
            set { m_PlaceValue = value; NotifyPropertyChanged(nameof(PlaceValue)); }
        }

        private int m_PathologyId;

        public int PathologyId
        {
            get { return m_PathologyId; }
            set { m_PathologyId = value; NotifyPropertyChanged(nameof(PathologyId)); }
        }

        private int m_CarLicPlateAssociationId;

        public int CarLicPlateAssociationId
        {
            get { return m_CarLicPlateAssociationId; }
            set { m_CarLicPlateAssociationId = value; 
                NotifyPropertyChanged(nameof(CarLicPlateAssociationId)); 
                NotifyPropertyChanged(nameof(LicPlateByAssociationId)); }
        }      

        private TimeSpan? m_ExitTime;

        public TimeSpan? ExitTime
        {
            get { return m_ExitTime; }
            set 
            {                
                m_ExitTime = value; 
                NotifyPropertyChanged(nameof(ExitTime)); 
            }
        }

        private TimeSpan? m_ReturnTime;

        public TimeSpan? ReturnTime
        {
            get { return m_ReturnTime; }
            set { m_ReturnTime = value; NotifyPropertyChanged(nameof(ReturnTime)); }
        }

        private int m_ExitKm;

        public int ExitKm
        {
            get { return m_ExitKm; }
            set { m_ExitKm = value; NotifyPropertyChanged(nameof(ExitKm)); }
        }

        private int m_ReturnKm;

        public int ReturnKm
        {
            get { return m_ReturnKm; }
            set 
            { 
                m_ReturnKm = value; 
                NotifyPropertyChanged(nameof(ReturnKm));
                NotifyPropertyChanged(nameof(KmDiff));
            }
        }

        private int m_DriverId;

        public int DriverId
        {
            get { return m_DriverId; }
            set { m_DriverId = value; NotifyPropertyChanged(nameof(DriverId)); }
        }

        private int m_Rescuer1Id;

        public int Rescuer1Id
        {
            get { return m_Rescuer1Id; }
            set { m_Rescuer1Id = value; NotifyPropertyChanged(nameof(Rescuer1Id)); }
        }

        private int m_Rescuer2Id;

        public int Rescuer2Id
        {
            get { return m_Rescuer2Id; }
            set { m_Rescuer2Id = value; NotifyPropertyChanged(nameof(Rescuer2Id)); }
        }

        private int m_BillNumber;

        public int BillNumber
        {
            get { return m_BillNumber; }
            set { m_BillNumber = value; NotifyPropertyChanged(nameof(BillNumber)); }
        }

        private int m_TagNumber;

        public int TagNumber
        {
            get { return m_TagNumber; }
            set { m_TagNumber = value; NotifyPropertyChanged(nameof(TagNumber)); }
        }

        private int m_EntityId; 
        public int EntityId
        {
            get { return m_EntityId; }
            set { m_EntityId = value; NotifyPropertyChanged(nameof(EntityId)); }
        }

        public string KmDiff 
        {
            get => (this.ReturnKm - this.ExitKm).ToString();
        }

        public string LicPlateByAssociationId
        {
            get
            {
                if (CarLicPlateAssociationId == -1)
                    return string.Empty;
                else
                {
                    CarLicencePlateAssociationEntity item = new CarLicPlateAssociationService().GetAssociationById(CarLicPlateAssociationId);
                    return item.LicencePlate;
                }
            }
        }

    }
}
