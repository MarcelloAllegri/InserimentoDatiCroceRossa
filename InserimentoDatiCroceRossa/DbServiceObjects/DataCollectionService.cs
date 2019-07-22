using InserimentoDatiCroceRossa.DbModel;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InserimentoDatiCroceRossa.DbServiceObjects
{
    public class DataCollectionService
    {
        public List<DataCollectionEntity> GetAllData()
        {
            List<Ins> dataDb = new List<Ins>();
            List<DataCollectionEntity> dataList = new List<DataCollectionEntity>();

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
            catch
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
    }

    public static class InsDbMapper
    {
        public static Ins ToIns(this DataCollectionEntity dataList, Ins ins = null)
        {
            if (ins == null) ins = new Ins();

            ins.InsOwnId = dataList.Id;
            ins.InsCarTarId = dataList.CarLicPlateAssociationId;
            ins.InsChrTo = dataList.EntityId;
            ins.InsIndId = dataList.AddressId;
            ins.InsKmInt = dataList.ReturnKm;
            ins.InsKmOut = dataList.ExitKm;
            ins.InsPatId = dataList.PathologyId;
            ins.InsPerId = dataList.PatientId;
            ins.InsSvrDat = dataList.ServiceDate;
            ins.InsSvrFrm = dataList.ServiceFromId;
            ins.InsSvrTo = dataList.ServiceToId;
            ins.InsTyp = dataList.ServiceType;
            ins.InsSoc1Id = dataList.Rescuer1Id;
            ins.InsSoc2Id = dataList.Rescuer2Id;
            ins.InsAutId = dataList.DriverId;
            ins.InsBilNum = dataList.BillNumber;
            ins.InsTimIn = dataList.ReturnTime;
            ins.InsTimOut = dataList.ExitTime;
            ins.InsCrtNum = dataList.TagNumber;
            return ins;
        }

        public static DataCollectionEntity toDataCollectionEntity(this Ins ins)
        {
            return new DataCollectionEntity()
            {
                Id = ins.InsOwnId,
                CarLicPlateAssociationId = ins.InsCarTarId,
                EntityId = ins.InsChrTo,
                AddressId = ins.InsIndId,
                ReturnKm = ins.InsKmInt,
                ExitKm = ins.InsKmOut,
                PathologyId = ins.InsPatId,
                PatientId = ins.InsPerId,
                ServiceDate = ins.InsSvrDat,            
                ServiceFromId = ins.InsSvrFrm,
                ServiceToId = ins.InsSvrTo,
                ServiceType = ins.InsTyp,
                Rescuer1Id = ins.InsSoc1Id,
                Rescuer2Id = ins.InsSoc2Id,
                DriverId = ins.InsAutId,
                BillNumber = ins.InsBilNum,
                ReturnTime = ins.InsTimIn,
                ExitTime = ins.InsTimOut,
                TagNumber = ins.InsCrtNum
            };
        }
    }
}

