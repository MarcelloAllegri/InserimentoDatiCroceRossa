using InserimentoDatiCroceRossa.DbModel;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.DbServiceObjects
{
    public class AddressService
    {
        public List<AddressEntity> GetAllAddresses()
        {
            List<Ind> inds = new List<Ind>();
            List<AddressEntity> addresses = new List<AddressEntity>();

            using (var db = new CroceRossaEntities())
            {
                inds = db.Ind.ToList();
            }
            inds.ForEach(ind => { addresses.Add(ind.toAddressEntity()); });
            return addresses;
        }

        public AddressEntity GetAddressById(int id)
        {
            AddressEntity address = new AddressEntity();
            if (id != -1) 
            {
                using (var db = new CroceRossaEntities())
                {
                    address = db.Ind.FirstOrDefault(x => x.IndOwnId == id).toAddressEntity();
                }
            }

            return address;
        }

        public int Add(AddressEntity address)
        {
            try
            {
                using(var db = new CroceRossaEntities())
                {
                    db.Ind.Add(address.ToInd());
                    db.SaveChanges();

                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }

        public int Update(AddressEntity address)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Ind ind = db.Ind.First(x => x.IndOwnId == address.Id);
                    if(ind!= null)
                    {
                        ind = address.ToInd(ind);
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

        public int Delete(AddressEntity address)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Ind ind = db.Ind.First(x => x.IndOwnId == address.Id);
                    if (ind != null)
                    {
                        db.Ind.Remove(ind);
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
    public static class IndDbMapper
    {
        public static Ind ToInd(this AddressEntity addressEntity,Ind ind  = null)
        {
            if (ind == null) ind = new Ind();

            ind.IndOwnId = addressEntity.Id;
            ind.IndVal = addressEntity.AddressName;

            return ind;
        }

        public static AddressEntity toAddressEntity(this Ind ind)
        {
            return new AddressEntity()
            {
                Id = ind.IndOwnId,
                AddressName = ind.IndVal
            };
        }
    }
}
    
