using InserimentoDatiCroceRossa.DbModel;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.DbClasses
{
    public class UsersService
    {
        public List<UserEntity> GetAllUser()
        {
            List<Usr> usr = new List<Usr>();
            List<UserEntity> users = new List<UserEntity>();

            using (var db = new CroceRossaEntities())
            {
                usr = db.Usr.ToList();
            }

            foreach (var item in usr)            
                users.Add(item.toUserEntity());

            return users;
            
        }

        public int Add(UserEntity user)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    db.Usr.Add(user.toUsr());
                    db.SaveChanges();

                    return 0;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Update(UserEntity user)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Usr usr = db.Usr.FirstOrDefault(x => x.UsrOwnId == user.Id);
                    if (usr != null)
                    {
                        usr = user.toUsr();
                        db.SaveChanges();
                    }
                }

                return 0;
            }
            catch (Exception)
            {
                return -1;                
            }
            
        }

        public int Delete(UserEntity user)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Usr usr = db.Usr.FirstOrDefault(x => x.UsrOwnId == user.Id);
                    if (usr != null)
                    {
                        db.Usr.Remove(usr);
                        db.SaveChanges();
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
            
        }
    }

    public static class UsrDbMapper
    {
        public static UserEntity toUserEntity(this Usr usr)
        {
            UserEntity user;
            if (usr == null) return new UserEntity();
            else user = new UserEntity(usr.UsrOwnId, usr.UsrNam, KriptoEntity.DecryptString(usr.UsrPsw), usr.UsrTyp[0]);

            return user;
        }

        public static Usr toUsr(this UserEntity user)
        {
            Usr usr = new Usr();

            usr.UsrOwnId = user.Id;
            usr.UsrNam = user.AccountName;
            usr.UsrPsw = KriptoEntity.EncryptString(user.Password);
            usr.UsrTyp = user.UserType.ToString();
            return usr;
        }
    }
}
