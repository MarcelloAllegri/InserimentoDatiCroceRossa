using InserimentoDatiCroceRossa.DbServiceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.Objects
{
    public class DataCollectionViewEntity : DataCollectionEntity
    {
        public DataCollectionViewEntity() : base()
        {
           
        }

        public string ServiceTypeToString
        {
            get
            {
                switch (base.ServiceType)
                {
                    case 1: return "Istituto";
                    case 2: return "Ordinario";
                    case 3: return "Urgente";
                    case 4: return "Protezione Civile";
                    case 5: return "Deceduto";
                    case 6: return "Altro Servizio";
                    case 7: return "Annullato";
                    default: return "Non specificato";
                }
            }
        }

        public string PatientFCdAndFullName
        {
            get
            {
                if(base.PatientId !=-1)
                {
                    PatientEntity patient = new PatientService().GetPatientById(base.PatientId);
                    return string.Concat(patient.FiscalCode, " ", patient.Surname, "-", patient.Name);
                }

                return string.Empty;
            }
        }

        public string AddressName
        {
            get { return base.AddressId == -1 ? string.Empty : new AddressService().GetAddressById(base.AddressId).AddressName; }
        }

        public string ServiceFrom
        {
            get { return base.ServiceFromId != -1 ? new CityService().GetCityById(base.ServiceFromId).CityName : string.Empty; }
        }

        public string ServiceTo
        {
            get { return base.ServiceToId != -1 ? new CityService().GetCityById(base.ServiceToId).CityName : string.Empty; }
        }

        public string AutoAndLicPlate
        {
            get
            {
                if (base.CarLicPlateAssociationId == -1)
                    return string.Empty;
                else
                {
                    CarLicencePlateAssociationEntity item = new CarLicPlateAssociationService().GetAssociationById(base.CarLicPlateAssociationId);
                    return string.Concat(item.CarName, " - ", item.LicencePlate);
                }
            }
        }

        public string DriverName
        {
            get { return base.DriverId == -1 ? string.Empty : new VolunteerService().GetVolunteerById(base.DriverId).SurnameAndName; }
        }

        public string Rescuer1Name
        {
            get { return base.Rescuer1Id == -1 ? string.Empty : new VolunteerService().GetVolunteerById(base.Rescuer1Id).SurnameAndName; }
        }

        public string Rescuer2Name
        {
            get { return base.Rescuer2Id == -1 ? string.Empty : new VolunteerService().GetVolunteerById(base.Rescuer2Id).SurnameAndName; }
        }

        public string EntityName
        {
            get { return base.EntityId == -1 ? string.Empty : new AuthorityService().GetAuthorityById(base.EntityId).AuthorityName; }
        }
    }
}
