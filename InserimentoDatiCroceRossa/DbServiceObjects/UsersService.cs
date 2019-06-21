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

        public void Add(UserEntity user)
        {
            using (var db = new CroceRossaEntities())
            {
                db.Usr.Add(user.toUsr());
                db.SaveChanges();
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
