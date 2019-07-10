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
            set { m_ServiceDate = value; }
        }

        private int m_ServiceFromId;

        public int ServiceFromId
        {
            get { return m_ServiceFromId; }
            set { m_ServiceFromId = value; }
        }

        private int m_ServiceToId;

        public int ServiceToId
        {
            get { return m_ServiceToId; }
            set { m_ServiceToId = value; }
        }

        private int m_ServiceType;

        public int ServiceType
        {
            get { return m_ServiceType; }
            set { m_ServiceType = value; }
        }

        private int m_PatientId;

        public int PatientId
        {
            get { return m_PatientId; }
            set { m_PatientId = value; }
        }

        private int m_AddressId;

        public int AddressId
        {
            get { return m_AddressId; }
            set { m_AddressId = value; }
        }

        private int m_PathologyId;

        public int PathologyId
        {
            get { return m_PathologyId; }
            set { m_PathologyId = value; }
        }

        private int m_CarLicPlateAssociationId;

        public int CarLicPlateAssociationId
        {
            get { return m_CarLicPlateAssociationId; }
            set { m_CarLicPlateAssociationId = value; }
        }

        private TimeSpan? m_ExitTime;

        public TimeSpan? ExitTime
        {
            get { return m_ExitTime; }
            set { m_ExitTime = value; }
        }

        private TimeSpan? m_ReturnTime;

        public TimeSpan? ReturnTime
        {
            get { return m_ReturnTime; }
            set { m_ReturnTime = value; }
        }

        private int m_ExitKm;

        public int ExitKm
        {
            get { return m_ExitKm; }
            set { m_ExitKm = value; }
        }

        private int m_ReturnKm;

        public int ReturnKm
        {
            get { return m_ReturnKm; }
            set { m_ReturnKm = value; }
        }

        private int m_DriverId;

        public int DriverId
        {
            get { return m_DriverId; }
            set { m_DriverId = value; }
        }

        private int m_Rescuer1Id;

        public int Rescuer1Id
        {
            get { return m_Rescuer1Id; }
            set { m_Rescuer1Id = value; }
        }

        private int m_Rescuer2Id;

        public int Rescuer2Id
        {
            get { return m_Rescuer2Id; }
            set { m_Rescuer2Id = value; }
        }

        private int m_BillNumber;

        public int BillNumber
        {
            get { return m_BillNumber; }
            set { m_BillNumber = value; }
        }

        private int m_TagNumber;

        public int TagNumber
        {
            get { return m_TagNumber; }
            set { m_TagNumber = value; }
        }

        private int m_EntityId; 
        public int EntityId
        {
            get { return m_EntityId; }
            set { m_EntityId = value; }
        }

    }
}
