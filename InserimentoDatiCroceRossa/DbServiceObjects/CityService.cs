using InserimentoDatiCroceRossa.DbModel;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.DbServiceObjects
{
    public class CityService
    {
        public List<CityEntity> GetAllCities()
        {
            List<Loc> locs = new List<Loc>();
            List<CityEntity> cities = new List<CityEntity>();

            using (var db = new CroceRossaEntities())
            {
                locs = db.Loc.ToList();
            }
            locs.ForEach(ind => { cities.Add(ind.toCityEntity()); });
            return cities;
        }

        public int Add(CityEntity cities)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    db.Loc.Add(cities.ToLoc());
                    db.SaveChanges();

                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }

        public int Update(CityEntity cities)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Loc loc = db.Loc.First(x => x.LocOwnId == cities.Id);
                    if (loc != null)
                    {
                        loc = cities.ToLoc(loc);
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

        public int Delete(CityEntity cities)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Loc loc = db.Loc.First(x => x.LocOwnId == cities.Id);
                    if (loc != null)
                    {
                        db.Loc.Remove(loc);
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
    public static class LocDbMapper
    {
        public static Loc ToLoc(this CityEntity cityEntity, Loc loc = null)
        {
            if (loc == null) loc = new Loc();

            loc.LocOwnId = cityEntity.Id;
            loc.LocPlc = cityEntity.CityName;

            return loc;
        }

        public static CityEntity toCityEntity(this Loc loc)
        {
            return new CityEntity()
            {
                Id = loc.LocOwnId,
                CityName = loc.LocPlc
            };
        }
    }
}

