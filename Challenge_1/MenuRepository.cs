using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class MenuRepository
    {
        //--Fields
        private List<Menu> _menu = new List<Menu>();

        public void AddItem(Menu menuItem)
        {
            _menu.Add(menuItem);
        }

        public void AddItems(List<Menu> menuItems)
        {
            foreach (Menu item in menuItems)
            {
                _menu.Add(item);
            }
        }

        public void RemoveItem(Menu menuItem)
        {
            foreach (Menu item in _menu)
            {
                if (item == menuItem)
                {
                    _menu.Remove(menuItem);
                    break;
                }
            }
        }

        public List<Menu> SortedMenu()
        {
            List<Menu> OrderedList = new List<Menu>();

            OrderedList = _menu.OrderBy(o => o.MealNumber).ToList();

            return OrderedList;
        }

        public List<Menu> GetMenu()
        {
            return _menu;
        }

        public void RemoveItem(int itemNumber)
        {
            foreach (Menu item in _menu)
            {
                if (item.MealNumber == itemNumber)
                {
                    _menu.Remove(item);
                    break;
                }
            }
        }
    }
}


//Your task is to do the following:
//1. Create a Menu class with properties, constructors, and fields.
//2. Create a MenuRepository class that has methods needed.
//3. Create a Test Class for your repository methods. (You don't need to test
//your constructors or objects.Just the methods.)
//4. Create a Program file that allows the restaurant manager to add, delete, 
//and see all items in the menu list.

//Notes:
//We don't need to update the items right now.
