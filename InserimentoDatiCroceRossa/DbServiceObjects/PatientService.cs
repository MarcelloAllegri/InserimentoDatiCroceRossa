using InserimentoDatiCroceRossa.DbModel;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InserimentoDatiCroceRossa.DbServiceObjects
{
    public class PatientService
    {
        public List<PatientEntity> GetAllPatients()
        {
            List<Per> perDbList = new List<Per>();
            List<PatientEntity> patients = new List<PatientEntity>();

            using (var db = new CroceRossaEntities())
            {
                perDbList = db.Per.ToList();
            }
            perDbList.ForEach(per => { patients.Add(per.toPatientEntity()); });
            return patients;
        }

        public int Add(PatientEntity patient)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    db.Per.Add(patient.ToPer());
                    db.SaveChanges();

                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }

        public int Update(PatientEntity patient)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Per per = db.Per.First(x => x.PerOwnId == patient.Id);
                    if (per != null)
                    {
                        per = patient.ToPer(per);
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

        public int Delete(PatientEntity patient)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Per per = db.Per.First(x => x.PerOwnId == patient.Id);
                    if (per != null)
                    {
                        db.Per.Remove(per);
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

    public static class PerDbMapper
    {
        public static Per ToPer(this PatientEntity patient, Per per = null)
        {
            if (per == null) per = new Per();

            per.PerOwnId = patient.Id;
            per.PerBir = patient.Bday;
            per.PerFCd = patient.FiscalCode;
            per.PerNam = patient.Name;
            per.PerSur = patient.Surname;
            per.PerSex = patient.Sex;
            
            return per;
        }

        public static PatientEntity toPatientEntity(this Per per)
        {
            return new PatientEntity()
            {
                Id = per.PerOwnId,
                Bday = per.PerBir,
                FiscalCode = per.PerFCd,
                Name = per.PerNam,
                Surname = per.PerSur,
                Sex = per.PerSex
            };
        }
    }
}
