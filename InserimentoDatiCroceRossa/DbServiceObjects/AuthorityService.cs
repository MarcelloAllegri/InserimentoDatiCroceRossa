using InserimentoDatiCroceRossa.DbModel;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.DbServiceObjects
{
    public class AuthorityService
    {
        public List<AuthorityEntity> GetAllAuthorities()
        {
            List<Ent> auth = new List<Ent>();
            List<AuthorityEntity> Authorities = new List<AuthorityEntity>();

            using (var db = new CroceRossaEntities())
            {
                auth = db.Ent.ToList();
            }
            auth.ForEach(ent => { Authorities.Add(ent.toAuthorityEntity()); });
            return Authorities;
        }

        public AuthorityEntity GetAuthorityById(int id)
        {
            AuthorityEntity authority = new AuthorityEntity();

            if(id != -1)
            {
                using (var db = new CroceRossaEntities())
                {
                    authority = db.Ent.FirstOrDefault(x => x.EntOwnId == id).toAuthorityEntity();
                }
            }

            return authority;
        }

        public int Add(AuthorityEntity entity)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    db.Ent.Add(entity.ToEnt());
                    db.SaveChanges();

                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }

        public int Update(AuthorityEntity entity)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Ent ent = db.Ent.First(x => x.EntOwnId == entity.Id);
                    if (ent != null)
                    {
                        ent = entity.ToEnt(ent);
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

        public int Delete(AuthorityEntity entity)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Ent ent = db.Ent.First(x => x.EntOwnId == entity.Id);
                    if (ent != null)
                    {
                        db.Ent.Remove(ent);
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
    public static class EntDbMapper
    {
        public static Ent ToEnt(this AuthorityEntity AuthorityEntity, Ent ent = null)
        {
            if (ent == null) ent = new Ent();

            ent.EntOwnId = AuthorityEntity.Id;
            ent.EntVal = AuthorityEntity.AuthorityName;

            return ent;
        }

        public static AuthorityEntity toAuthorityEntity(this Ent ent)
        {
            return new AuthorityEntity()
            {
                Id = ent.EntOwnId,
                AuthorityName = ent.EntVal
            };
        }
    }
}

