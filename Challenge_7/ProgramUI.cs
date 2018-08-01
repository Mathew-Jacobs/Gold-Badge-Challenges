using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    public class ProgramUI
    {
        public void Run()
        {
            Party initParty = InitParty();
            Console.WriteLine(initParty.TotalCost);
            Console.Read();
        }

        private Party InitParty()
        {
            List<Food> burgfoods = new List<Food>()
            {
                new Food("Burger",2.99m,34),
                new Food("Hotdogs",1.99m,25),
                new Food("Veggie Burger",3.99m,13)
            };
            List<Food> sweetsFood = new List<Food>()
            {
                new Food("Iced Cream",0.99m,30),
                new Food("Cupcake",1.99m,34),
                new Food("Chocolate Chip Cookie", 0.99m,25)
            };
            List<Booth> booths = new List<Booth>()
            {
                new Booth("Burger Shack", burgfoods, 0.5m),
                new Booth("Sweet Stuff", sweetsFood, 0.6m)
            };
            Party party = new Party(booths);
            return party;
        }
    }
}
