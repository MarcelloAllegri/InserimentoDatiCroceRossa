using InserimentoDatiCroceRossa.DbModel;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.DbServiceObjects
{
    public class CarLicPlateAssociationService
    {
        public List<CarLicencePlateAssociationEntity> GetAllAssociation()
        {
            List<CarTar> carTasAssociations = new List<CarTar>();
            List<CarLicencePlateAssociationEntity> Association = new List<CarLicencePlateAssociationEntity>();

            using (var db = new CroceRossaEntities())
            {
                carTasAssociations = db.CarTar.ToList();
            }
            carTasAssociations.ForEach(ent => { Association.Add(ent.toCarLicencePlateAssociationEntity()); });
            return Association;
        }

        public int Add(CarLicencePlateAssociationEntity entity)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    CarTar carTar = entity.toCarTar();
                    db.CarTar.Add(carTar);
                    db.SaveChanges();

                    return carTar.CarTarOwnId;
                }
            }
            catch
            {
                return -1;
            }
        }

        public int Update(CarLicencePlateAssociationEntity entity)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    CarTar carTar = db.CarTar.First(x => x.CarTarOwnId == entity.Id);
                    if (carTar != null)
                    {
                        carTar = entity.toCarTar(carTar);
                        db.SaveChanges();
                    }
                    return 0;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Delete(CarLicencePlateAssociationEntity entity)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    CarTar carTar = db.CarTar.First(x => x.CarTarOwnId == entity.Id);
                    if (carTar != null)
                    {
                        db.CarTar.Remove(carTar);
                        db.SaveChanges();
                    }
                    return 0;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }

    public static class CarLicPlateAssociationMapper
    {
        public static CarLicencePlateAssociationEntity toCarLicencePlateAssociationEntity(this CarTar carTar)
        {
            CarLicencePlateAssociationEntity association = new CarLicencePlateAssociationEntity();

            association.CarId = carTar.CarId;
            association.Id = carTar.CarTarOwnId;
            association.IsEnabled = carTar.CarTarEnb;
            association.LicencePlateId = carTar.TarId;

            return association;
        }

        public static CarTar toCarTar(this CarLicencePlateAssociationEntity association, CarTar carTar = null)
        {
            if (carTar == null) carTar = new CarTar();

            carTar.CarId = association.CarId;
            carTar.CarTarOwnId = association.Id;
            carTar.CarTarEnb = association.IsEnabled;
            carTar.TarId = association.LicencePlateId;

            return carTar;
        }
    }
}
