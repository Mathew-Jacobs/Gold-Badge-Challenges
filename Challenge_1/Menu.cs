using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class Menu
    {
        public Menu() { }

        public Menu(string mealName, int mealNumber, List<string> ingredientsList, string mealDescription, decimal mealPrice)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            IngredientsList = ingredientsList;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
        }
        public bool error = false;
        public string errorMsg = "";
        private string _mealName;
        private int _mealNumber;
        private List<string> _ingredientList;
        private string _mealDiscription;
        private decimal _mealPrice;

        public string MealName
        {
            get { return _mealName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    error = true;
                    errorMsg += "Forgot Meal Name\n";
                }
                else
                {
                    _mealName = value;
                }
            }
        }
        public int MealNumber
        {
            get { return _mealNumber; }
            set
            {
                if (value < 0)
                {
                    error = true;
                    errorMsg += "Invalid Menu Number\n";
                }
                _mealNumber = value;
            }
        }
        public List<string> IngredientsList
        {
            get { return _ingredientList; }
            set { _ingredientList = value; }
        }
        public string MealDescription
        {
            get { return _mealDiscription; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    error = true;
                    errorMsg += "Forgot Description\n";
                }
                else
                {
                    _mealDiscription = value;
                }
            }
        }
        public decimal MealPrice
        {
            get { return _mealPrice; }
            set
            {
                if (value < 0)
                {
                    error = true;
                    errorMsg += "Invalid Meal Price\n";
                }
                _mealPrice = value;
            }
        }

        public override string ToString()
        {
            return $"|{MealName}\t\t|{MealNumber}\t\t|{MealDescription}\t\t|{MealPrice}|";
        }
    }
}