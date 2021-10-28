using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CarsBusiness
    {
        private CarsContext carsContext;

        public void AddOwner(CarOwner carOwner)
        {
            using (carsContext = new CarsContext())
            {
                carsContext.CarOwners.Add(carOwner);
                carsContext.SaveChanges();
            }
        }

        public void UpdateOwner(CarOwner carOwner)
        {
            using (carsContext = new CarsContext())
            {
                var oldCarOwner = carsContext.CarOwners.Find(carOwner.Id);
                carsContext.Entry(oldCarOwner).CurrentValues.SetValues(carOwner);
                carsContext.SaveChanges();
            }
        }

        public void AddCars(Cars cars)
        {
            using (carsContext = new CarsContext())
            {
                carsContext.Cars.Add(cars);
                carsContext.SaveChanges();
            }
        }

        public string GetModels()
        {
            using (carsContext = new CarsContext())
            {
                var car = carsContext.Cars.Select(p => new
                {
                    p.Models,
                    FirstName = p.CarOwner.FirstName,
                    LastName = p.CarOwner.LastName
                });
                var sb = new StringBuilder();
                foreach (var item in car)
                {
                    sb.AppendLine($" {item.Models} {item.FirstName} {item.LastName}");
                }
                return sb.ToString().Trim();
            }
        }

        public string GetOwner(int id)
        {
            using (carsContext = new CarsContext())
            {
                var car = carsContext.Cars.Where(x => x.CarOwner.Id == id).ToList();
                if (car != null)
                {
                    var sb = new StringBuilder();
                    foreach (var item in car)
                    {
                        sb.AppendLine($" {item.CarsOwnerId} {item.Models} {item.Year}");
                    }
                    return sb.ToString().Trim();
                }
                return null;
            }
        }

        public Cars ShowModels(int id)
        {
            using (carsContext = new CarsContext())
            {
                var car = carsContext.Cars.Find(id);
                return car;
            }
        }

        public void UpdateModels(Cars cars)
        {
            using (carsContext = new CarsContext())
            {
                var oldCarOwner = carsContext.Cars.Find(cars.Models);
                carsContext.Entry(oldCarOwner).CurrentValues.SetValues(cars);
                carsContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (carsContext = new CarsContext())
            {
                var models = carsContext.Cars.Find(id);
                if (models != null)
                {
                    carsContext.Cars.Remove(models);
                    carsContext.SaveChanges();
                }
            }
        }
    }
}
