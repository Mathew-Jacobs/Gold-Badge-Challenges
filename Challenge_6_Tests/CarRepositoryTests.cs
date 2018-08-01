using System;
using System.Collections.Generic;
using Challenge_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_6_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private CarRepository _carRepo = new CarRepository();
        [TestMethod]
        public void CarRepository_GetCars_ShouldReturnSeletedTypes()
        {
            //--Arrange
            InitCars();
            List<Car> cars = _carRepo.GetCars(CarTypes.Electric);

            //--Act
            int actual = cars.Count;
            int expected = 3;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CarRepository_AddCar_ShouldAddCarToList()
        {
            //--Arrange
            InitCars();
            Car car = new Car("make", "model", 2014, 35.00m, CarTypes.Gas);
            _carRepo.AddCar(car);

            //--Act
            int actual = _carRepo.GetCars(CarTypes.All).Count;
            int expected = 10;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CarRepository_AddCars_ShouldAddCarListToList()
        {
            //--Arrange
            InitCars();
            List<Car> cars = _carRepo.GetCars(CarTypes.Electric);
            _carRepo.AddCar(cars);

            //--Act
            int actual = _carRepo.GetCars(CarTypes.All).Count;
            int expected = 12;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CarRepository_RemoveCar_ShouldRemoveCarFromList()
        {
            //--Arrange
            InitCars();
            Car car = _carRepo.GetCars(CarTypes.All)[0];
            _carRepo.RemoveCar(car);
            

            //--Act
            int actual = _carRepo.GetCars(CarTypes.All).Count;
            int expected = 8;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
        private void InitCars()
        {
            Car[] car = new Car[9];
            car[0] = new Car("Tesla", "Model S", 2017, 125.00m, CarTypes.Electric);
            car[1] = new Car("Nissan", "Leaf", 2018, 125.00m, CarTypes.Electric);
            car[2] = new Car("Volkswagon", "e-Golf", 2017, 126.00m, CarTypes.Electric);
            car[3] = new Car("Toyota", "Prius", 2017, 43.00m, CarTypes.Hybrid);
            car[4] = new Car("Ford", "Fusion", 2018, 34.00m, CarTypes.Hybrid);
            car[5] = new Car("Honda", "Accord", 2018, 38.00m, CarTypes.Hybrid);
            car[6] = new Car("Honda", "Civic", 2018, 32.00m, CarTypes.Gas);
            car[7] = new Car("Ford", "Mustang", 2019, 21.00m, CarTypes.Gas);
            car[8] = new Car("Chrysler", "Pacifica", 2019, 19.00m, CarTypes.Gas);

            for (int i = 0; i < car.Length; i++)
            {
                _carRepo.AddCar(car[i]);
            }
        }
    }
}
