using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    public class ProgramUI
    {

        public void Run()
        {
            
            Console.WriteLine("This Data would be automatically attained by the vehicle in the full product\n" +
                "However we will input it manually for this scope\n");
            Console.WriteLine("\nIn decimal form what percent of the time are you speeding? (1 being 100%)");
            decimal speeding = decimal.Parse(Console.ReadLine());
            Console.WriteLine("\nIn decimal form what percent of stopsigns do you roll through?");
            decimal stopsign = decimal.Parse(Console.ReadLine());
            Console.WriteLine("\nIn decimal form what percent of time have you fallen out of lane?");
            decimal outOfLane = decimal.Parse(Console.ReadLine());
            Console.WriteLine("\nIn decimal form what percent of time spent tailgaiting");
            decimal tailgaiting = decimal.Parse(Console.ReadLine());

            Car car = new Car(speeding, stopsign, outOfLane, tailgaiting);
            Premium premium = new Premium(car);
            Console.WriteLine($"Your calculated premium based on risk factors is {premium.CalcPremium}");
            Console.ReadKey();
        }

        //public Car(decimal speeding, decimal stopsign, decimal outOfLane, decimal tailgating)
    }
}
