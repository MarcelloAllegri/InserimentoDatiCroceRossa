using InserimentoDatiCroceRossa.DbModel;
using InserimentoDatiCroceRossa.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserimentoDatiCroceRossa.DbServiceObjects
{
    public class AutoService
    {
        public List<AutoEntity> GetAllCars()
        {
            List<Car> cars = new List<Car>();
            List<AutoEntity> auto = new List<AutoEntity>();
            using (var db = new CroceRossaEntities())
            {
                cars = db.Car.ToList();
            }

            cars.ForEach(x => { auto.Add(x.toAutoEntity()); });
            return auto;
        }

        public int Add(AutoEntity auto)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    db.Car.Add(auto.toCar());
                    db.SaveChanges();

                    return 0;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Update(AutoEntity auto)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Car Car = db.Car.First(x => x.CarOwnId == auto.Id);
                    if (Car != null)
                    {
                        Car = auto.toCar(Car);
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

        public int Delete(AutoEntity auto)
        {
            try
            {
                using (var db = new CroceRossaEntities())
                {
                    Car Car = db.Car.FirstOrDefault(x => x.CarOwnId == auto.Id);
                    if (Car != null)
                    {
                        db.Car.Remove(Car);
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

    public static class AutoServiceMapper
    {
        public static AutoEntity toAutoEntity(this Car car)
        {
            AutoEntity auto = new AutoEntity();

            auto.CarName = car.CarNam;
            auto.Id = car.CarOwnId;

            return auto;
        }

        public static Car toCar(this AutoEntity auto, Car car = null)
        {
            if (car == null) car = new Car();

            car.CarOwnId = auto.Id;
            car.CarNam = auto.CarName;

            return car;
        }
    }
}
