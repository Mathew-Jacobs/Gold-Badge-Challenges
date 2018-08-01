using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    class MenuUI
    {
        //--Fields
        private bool loop = true;
        MenuRepository _menuRepo = new MenuRepository();


        public void Run()
        {
            List<string> exampleIngredients = new List<string>();
            exampleIngredients.Add("example1");
            exampleIngredients.Add("example2");
            exampleIngredients.Add("example3");
            exampleIngredients.Add("example4");

            var menuItems = new List<Menu>()
            {
                new Menu("Cheese Burger", 1, exampleIngredients, "A basic cheeseburger", 2.99m),
                new Menu("Chicken Nuggets", 2, exampleIngredients, "5 piece chicken nuggets", 1.99m),
                new Menu("Garden Salad", 3, exampleIngredients, "Salad with ranch dressing", 3.99m),
            };
            _menuRepo.AddItems(menuItems);

            while (loop)
            {
                string menuInput = ConsoleMenu();
                switch (menuInput)
                {
                    case "1":
                        Menu Item = AddToMenu();
                        _menuRepo.AddItem(Item);
                        Console.Clear();
                        break;
                    case "2":
                        List<Menu> OrderdList = _menuRepo.SortedMenu();
                        foreach (Menu item in OrderdList)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("Enter the number of the item you would like to remove:");
                        int itemNumber = int.Parse(Console.ReadLine());
                        _menuRepo.RemoveItem(itemNumber);
                        Console.Clear();
                        break;
                    case "X":
                        loop = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown Input");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

        }

        public string ConsoleMenu()
        {
            Console.WriteLine($"Select an option:\r\n" +
                $"\r\n" +
                $"[1] Add Item to Menu\r\n" +
                $"[2] View Menu\n" +
                $"[3] Remove an Item\n" +
                $"[X] Exit\n");
            System.ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            return input.KeyChar.ToString();
        }

        public Menu AddToMenu()
        {
            bool y = true;
            List<string> _ingredientList = new List<string>();
            Console.WriteLine("Enter the Item's Name:");
            string mealName = Console.ReadLine();
            Console.WriteLine("Enter the Meal Number:");
            int mealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Description:");
            string mealDescription = Console.ReadLine();
            Console.WriteLine("Enter the price:");
            decimal mealPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the first Ingredient for the meal:");
            while (y)
            {
                string ingredient = Console.ReadLine();
                _ingredientList.Add(ingredient);
                Console.WriteLine("Would you like to add more ingredients? (y/n)");
                System.ConsoleKeyInfo input = Console.ReadKey();
                string response = input.KeyChar.ToString();
                bool trying = true;
                while (trying)
                    switch (response)
                    {
                        case "y":
                            Console.Clear();
                            Console.WriteLine("Enter the next Ingredient:");
                            y = true;
                            trying = false;
                            break;
                        case "n":
                            y = false;
                            trying = false;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Unknown input\r\n" +
                                "Please use 'y' or 'n'\n" +
                                "Would you like to add more ingredients? (y/n)");
                            System.ConsoleKeyInfo newinput = Console.ReadKey();
                            response = newinput.KeyChar.ToString();
                            break;
                    }
            }
            Menu Item = new Menu(mealName, mealNumber, _ingredientList, mealDescription, mealPrice);
            return Item;
        }
    }
}
