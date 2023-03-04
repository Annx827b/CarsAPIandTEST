using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarsAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarClassLibary;
using System.Reflection;

namespace CarsAPI.Repositories.Tests
{
    [TestClass()]
    public class CarsRepositoryTests
    {
        CarsRepository repository = new CarsRepository();
       
        [TestMethod()]
        public void GetAllTest()
        {
            List<Car> cars = repository.GetAll();

            var expectedCarCount = 6;
            Assert.IsNotNull(cars);
            Assert.AreEqual(expectedCarCount, cars.Count);
            Assert.AreEqual(cars[5].Model, "Lupo");
            Assert.AreEqual(cars[4].Price, 40500);
            Assert.AreEqual(cars[0].LicensePlate, "FC1020"); 
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var foundCar = repository.GetById(4);
            
            Assert.IsNotNull(foundCar);
            Assert.AreEqual(foundCar.Model, "Fiat Panda");  
        }

        [TestMethod()]
        public void AddTest()
        {
            Car carToBeAdded = new Car() {Id = 7, Model = "Audi", Price = 167000, LicensePlate = "AB1021"};
            repository.Add(carToBeAdded);

            List<Car> cars = repository.GetAll();
            Assert.IsNotNull(carToBeAdded);
            var expectedCarCount = 7;

            Assert.AreEqual(cars[6].Model, "Audi");
            Assert.AreEqual(expectedCarCount, cars.Count);

        } 

    }
}

    