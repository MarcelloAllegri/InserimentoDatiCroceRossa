using InserimentoDatiCroceRossa.DbModel;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.DbServiceObjects
{
    public class LicencePlateService
    {
        public List<LicencePlateEntity> GetAllLicencePlates()
        {
            List<Tar> licPlatesDb = new List<Tar>();
            List<LicencePlateEntity> licencePlates = new List<LicencePlateEntity>();

            using (var db = new CroceRossaEntities())
            {
                licPlatesDb = db.Tar.ToList();
            }
            licPlatesDb.ForEach(tar => { licencePlates.Add(tar.toLicencePlateEntity()); });
            return licencePlates;
        }

        public int Add(LicencePlateEntity licencePlates)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    db.Tar.Add(licencePlates.ToTar());
                    db.SaveChanges();

                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }

        public int Update(LicencePlateEntity licencePlates)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Tar tar = db.Tar.First(x => x.TarOwnId == licencePlates.Id);
                    if (tar != null)
                    {
                        tar = licencePlates.ToTar(tar);
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

        public int Delete(LicencePlateEntity licencePlates)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Tar tar = db.Tar.First(x => x.TarOwnId == licencePlates.Id);
                    if (tar != null)
                    {
                        db.Tar.Remove(tar);
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
    public static class TarDbMapper
    {
        public static Tar ToTar(this LicencePlateEntity licencePlatesEntity, Tar tar = null)
        {
            if (tar == null) tar = new Tar();

            tar.TarOwnId = licencePlatesEntity.Id;
            tar.TarVal = licencePlatesEntity.Targa;

            return tar;
        }

        public static LicencePlateEntity toLicencePlateEntity(this Tar tar)
        {
            return new LicencePlateEntity()
            {
                Id = tar.TarOwnId,
                Targa = tar.TarVal
            };
        }
    }
}

