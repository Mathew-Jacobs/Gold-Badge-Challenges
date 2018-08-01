using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    public enum CarTypes
    {
        Electric, Hybrid, Gas, All
    }

    public class Car
    {
        public Car(string make, string model, int year, decimal mpg, CarTypes carType)
        {
            Make = make;
            Model = model;
            Year = year;
            MPG = mpg;
            CarType = carType;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal MPG { get; set; }
        public CarTypes CarType { get; set; }

        public override string ToString()
        {
            return $"{Make}\t\t{Model}\t\t{Year}\t\t{MPG}\t\t{CarType}";
        }
    }
}
