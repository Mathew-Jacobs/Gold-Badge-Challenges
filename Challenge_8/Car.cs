using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    public class Car
    {
        public Car(decimal speeding, decimal stopsign, decimal outOfLane, decimal tailgating)
        {
            Speeding = speeding;
            RollStopsign = stopsign;
            OutOfLane = outOfLane;
            Tailgating = tailgating;
            TotalRisk = Speeding + RollStopsign + OutOfLane + Tailgating;
        }
        public decimal Speeding { get; set; }
        public decimal RollStopsign { get; set; }
        public decimal OutOfLane { get; set; }
        public decimal Tailgating { get; set; }
        public decimal TotalRisk { get; set; }
    }
}
