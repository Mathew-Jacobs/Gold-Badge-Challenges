using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class Menu
    {

        public Menu(string mealName, int mealNumber, List<string> ingredientsList, string mealDescription, decimal mealPrice)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            IngredientsList = ingredientsList;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
        }

        public string MealName { get; set; }
        public int MealNumber { get; set; }
        public List<string> IngredientsList { get; set; }
        public string MealDescription { get; set; }
        public decimal MealPrice { get; set; }

        public override string ToString()
        {
            return $"|{MealName}\t\t|{MealNumber}\t\t|{MealDescription}\t\t|{MealPrice}|";
        }
    }
}