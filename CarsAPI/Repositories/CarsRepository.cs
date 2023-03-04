using CarClassLibary;
using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace CarsAPI.Repositories
{
    public class CarsRepository
    {

        private List<Car> cars;

        private int nextId;

        public CarsRepository()
        {
            nextId = 1;
            cars = new List<Car>()
            {
                new Car() { Id = nextId++, Model = "Tesla", Price = 1000000, LicensePlate = "FC1020" },
                new Car() { Id = nextId++, Model = "Opel", Price = 80000, LicensePlate = "AV8034" },
                new Car() { Id = nextId++, Model = "Olé", Price = 1000, LicensePlate = "PO6700" },
                new Car() { Id = nextId++, Model = "Fiat Panda", Price = -12000, LicensePlate = "BV2034" },
                new Car() { Id = nextId++, Model = "Peugeot", Price = 40500, LicensePlate = "KI3945" },
                new Car() { Id = nextId++, Model = "Lupo", Price = 90050, LicensePlate = "WL2834" }
            };
        }

        public List<Car> GetAll()
        {
            return cars;
        }


        public Car? GetById(int id)
        {
            return cars.Find(car => car.Id == id);
        }

        public Car Add(Car newCar)
        {
            newCar.Id = nextId++;
            newCar.ValidateModel();
            newCar.ValidatePrice();
            newCar.ValidateLicensePlate();
            cars.Add(newCar);

            return newCar;
        }

        public Car? Delete(int id)
        {
            Car? carToBeRemoved = GetById(id);
            if (carToBeRemoved == null) return null;
            cars.Remove(carToBeRemoved);
            return carToBeRemoved;
        }

        public Car? Update(int id, Car updates)
        {
            updates.Validate();
            Car? carToBeUpdated = GetById(id);
            if (carToBeUpdated == null) return null;
            carToBeUpdated.Model = updates.Model;
            carToBeUpdated.Price = updates.Price;
            carToBeUpdated.LicensePlate = updates.LicensePlate;

            return carToBeUpdated;
        }


    }
}


