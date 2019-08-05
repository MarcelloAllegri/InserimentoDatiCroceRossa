using InserimentoDatiCroceRossa.DbModel;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InserimentoDatiCroceRossa.DbServiceObjects
{
    public class VolunteerService
    {
        public List<VolunteerEntity> GetAllVolunteers()
        {
            List<Vol> volDbList = new List<Vol>();
            List<VolunteerEntity> volunteers = new List<VolunteerEntity>();

            using (var db = new CroceRossaEntities())
            {
                volDbList = db.Vol.ToList();
            }
            volDbList.ForEach(vol => { volunteers.Add(vol.toVolunteerEntity()); });
            return volunteers;
        }

        public VolunteerEntity GetVolunteerById(int id)
        {
            VolunteerEntity volunteer = new VolunteerEntity();

            using (var db = new CroceRossaEntities())
            {
                volunteer = db.Vol.FirstOrDefault(x => x.VolOwnId == id).toVolunteerEntity();
            }

            return volunteer;
        }

        public int Add(VolunteerEntity volunteer)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    db.Vol.Add(volunteer.ToVol());
                    db.SaveChanges();

                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }

        public int Update(VolunteerEntity volunteer)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Vol vol = db.Vol.First(x => x.VolOwnId == volunteer.Id);
                    if (vol != null)
                    {
                        vol = volunteer.ToVol(vol);
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

        public int Delete(VolunteerEntity volunteer)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Vol vol = db.Vol.First(x => x.VolOwnId == volunteer.Id);
                    if (vol != null)
                    {
                        db.Vol.Remove(vol);
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

    public static class VolDbMapper
    {
        public static Vol ToVol(this VolunteerEntity volunteer, Vol vol = null)
        {
            if (vol == null) vol = new Vol();

            vol.VolOwnId = volunteer.Id;
            vol.VolNam = volunteer.Name;
            vol.VolSur = volunteer.Surname;

            return vol;
        }

        public static VolunteerEntity toVolunteerEntity(this Vol vol)
        {
            return new VolunteerEntity()
            {
                Id = vol.VolOwnId,
                Name = vol.VolNam,
                Surname = vol.VolSur,
            };
        }
    }
}
