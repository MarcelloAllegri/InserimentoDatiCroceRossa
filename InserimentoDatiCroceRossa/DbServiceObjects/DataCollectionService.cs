using InserimentoDatiCroceRossa.DbModel;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InserimentoDatiCroceRossa.DbServiceObjects
{
    public class DataCollectionService
    {
        public List<DataCollectionViewEntity> GetAllData()
        {
            List<Ins> dataDb = new List<Ins>();
            List<DataCollectionViewEntity> dataList = new List<DataCollectionViewEntity>();

            using (var db = new CroceRossaEntities())
            {
                dataDb = db.Ins.ToList();
            }
            dataDb.ForEach(ins => { dataList.Add(ins.toDataCollectionEntity()); });
            return dataList;
        }

        public int Add(DataCollectionEntity dataList)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    db.Ins.Add(dataList.ToIns());
                    db.SaveChanges();

                    return 0;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int Update(DataCollectionEntity dataList)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Ins ins = db.Ins.First(x => x.InsOwnId == dataList.Id);
                    if (ins != null)
                    {
                        ins = dataList.ToIns(ins);
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

        public int Delete(DataCollectionEntity dataList)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Ins ins = db.Ins.First(x => x.InsOwnId == dataList.Id);
                    if (ins != null)
                    {
                        db.Ins.Remove(ins);
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
        public int GetKmByAssociationId(int Id)
        {
            int km = 0;

            using (var db = new CroceRossaEntities())
            {
                if (db.Ins.Any() && db.Ins.Any(x => x.InsCarTarId == Id))
                    km = db.Ins.Where(x => x.InsCarTarId == Id).Max(x => x.InsKmInt);
            }

            return km;
        }
    }

    public static class InsDbMapper
    {
        public static Ins ToIns(this DataCollectionEntity dataList, Ins ins = null)
        {
            if (ins == null) ins = new Ins();

            ins.InsOwnId = dataList.Id;
            ins.InsCarTarId = dataList.CarLicPlateAssociationId;
            ins.InsChrTo = dataList.EntityId;
            ins.InsIndFrom = dataList.AddressValueFrom;
            ins.InsKmInt = dataList.ReturnKm;
            ins.InsKmOut = dataList.ExitKm;
            ins.InsPatId = dataList.PathologyId;
            ins.InsPerId = dataList.PatientId;
            ins.InsSvrDat = dataList.ServiceDate;            
            ins.InsTyp = dataList.ServiceType;
            ins.InsSoc1Id = dataList.Rescuer1Id;
            if (dataList.Rescuer2Id != -1)
                ins.InsSoc2Id = dataList.Rescuer2Id;
            else ins.InsSoc2Id = null;
            ins.InsAutId = dataList.DriverId;
            ins.InsBilNum = dataList.BillNumber;
            ins.InsTimIn = dataList.ReturnTime;
            ins.InsTimOut = dataList.ExitTime;
            ins.InsCrtNum = dataList.TagNumber;
            ins.InsPlcFrom = dataList.PlaceValueFrom;
            ins.InsPlcTo = dataList.PlaceValueTo;
            ins.InsIndTo = dataList.AddressValueTo;

            return ins;
        }

        public static DataCollectionViewEntity toDataCollectionEntity(this Ins ins)
        {
            return new DataCollectionViewEntity()
            {
                Id = ins.InsOwnId,
                CarLicPlateAssociationId = ins.InsCarTarId,
                EntityId = ins.InsChrTo,
                AddressValueFrom = ins.InsIndFrom,
                ReturnKm = ins.InsKmInt,
                ExitKm = ins.InsKmOut,
                PathologyId = ins.InsPatId,
                PatientId = ins.InsPerId,
                ServiceDate = ins.InsSvrDat,               
                ServiceType = ins.InsTyp,
                Rescuer1Id = ins.InsSoc1Id,
                Rescuer2Id = ins.InsSoc2Id.HasValue ? ins.InsSoc2Id.Value : -1,
                DriverId = ins.InsAutId,
                BillNumber = ins.InsBilNum,
                ReturnTime = ins.InsTimIn,
                ExitTime = ins.InsTimOut,
                TagNumber = ins.InsCrtNum,
                PlaceValueFrom = ins.InsPlcFrom,
                PlaceValueTo = ins.InsPlcTo,
                AddressValueTo = ins.InsIndTo
            };
        }
    }
}

