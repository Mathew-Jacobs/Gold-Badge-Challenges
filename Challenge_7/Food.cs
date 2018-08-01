using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    public class Food
    {
        public Food() { }

        public Food(string name, decimal price, int usedTickets)
        {
            Name = name;
            Price = price;
            UsedTickets = usedTickets;
            TotalCost = price * usedTickets;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UsedTickets { get; set; }
        public decimal TotalCost { get; set; }

    }
}
