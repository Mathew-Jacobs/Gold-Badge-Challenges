using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    public class CarRepository
    {

        private List<Car> _carList = new List<Car>();

        public List<Car> GetCars(CarTypes carType)
        {
            switch (carType)
            {
                case CarTypes.Electric:
                    List<Car> elecCars = new List<Car>();
                    foreach (Car car in _carList)
                    {
                        if (car.CarType == CarTypes.Electric)
                        {
                            elecCars.Add(car);
                        }
                    }
                    return elecCars;
                case CarTypes.Hybrid:
                    List<Car> hybridCars = new List<Car>();
                    foreach (Car car in _carList)
                    {
                        if (car.CarType == CarTypes.Hybrid)
                        {
                            hybridCars.Add(car);
                        }
                    }
                    return hybridCars;
                case CarTypes.Gas:
                    List<Car> gasCars = new List<Car>();
                    foreach (Car car in _carList)
                    {
                        if (car.CarType == CarTypes.Gas)
                        {
                            gasCars.Add(car);
                        }
                    }
                    return gasCars;
                case CarTypes.All:
                    return _carList;
                default:
                    return _carList;
            }
        }

        public void AddCar(Car car)
        {
            _carList.Add(car);
        }
        public void AddCar(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                _carList.Add(car);
            }
        }

        public void RemoveCar(Car car)
        {
            _carList.Remove(car);
        }


    }
}
