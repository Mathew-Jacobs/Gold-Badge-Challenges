using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    public class Booth
    {
        public Booth() { }

        public Booth(string boothName, List<Food> foods, decimal miscCostPerPerson)
        {
            BoothName = boothName;
            Foods = foods;
            foreach(Food food in Foods)
            {
                TotalTickets += food.UsedTickets;
                TotalCost += food.TotalCost;
                MiscCosts += miscCostPerPerson*food.UsedTickets;
            }
            TotalCost += MiscCosts;
        }

        public string BoothName { get; set; }
        public List<Food> Foods { get; set; }
        public int TotalTickets { get; set; }
        public decimal TotalCost { get; set; }
        public decimal MiscCosts { get; set; }

    }
}
