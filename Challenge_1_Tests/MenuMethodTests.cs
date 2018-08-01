using System;
using System.Collections.Generic;
using Challenge_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_1_Tests
{
    [TestClass]
    public class MenuMethodTests
    {
        [TestMethod]
        public void MenuRepository_AddItem_ShouldAddItemToList()
        {
            //--Arrange
            MenuRepository _menuRepo = new MenuRepository();
            List<string> ingredientList = new List<string>();
            Menu item = new Menu("Burger", 1, ingredientList, "Borgor", 2.99m);
            _menuRepo.AddItem(item);
            List<Menu> menuList = _menuRepo.GetMenu();

            //--Act
            int actual = menuList.Count;
            int expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_AddItems_ShouldAddItemsToList()
        {
            //--Arrange
            MenuRepository _menuRepo = new MenuRepository();
            List<string> ingredientList = new List<string>();
            List<Menu> menuList = new List<Menu>()
            {
                new Menu("Burger", 1, ingredientList, "Borgor", 2.99m),
                new Menu("Fries", 2, ingredientList, "Fries", 0.99m),
            };
            _menuRepo.AddItems(menuList);
            List<Menu> MenuList = _menuRepo.GetMenu();

            //--Act
            int actual = MenuList.Count;
            int expected = 2;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_Remove_ShouldRemoveItemToList()
        {
            //--Arrange
            MenuRepository _menuRepo = new MenuRepository();
            List<string> ingredientList = new List<string>();
            List<Menu> menuList = new List<Menu>()
            {
                new Menu("Burger", 1, ingredientList, "Borgor", 2.99m),
            };
            Menu item = new Menu("Fries", 2, ingredientList, "Fries", 0.99m);
            menuList.Add(item);
            _menuRepo.AddItems(menuList);
            _menuRepo.RemoveItem(item);
            menuList = _menuRepo.GetMenu();

            //--Act
            int actual = menuList.Count;
            int expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MenuRepository_RemoveInt_ShouldRemoveItemToList()
        {
            //--Arrange
            MenuRepository _menuRepo = new MenuRepository();
            List<string> ingredientList = new List<string>();
            List<Menu> menuList = new List<Menu>()
            {
                new Menu("Burger", 1, ingredientList, "Borgor", 2.99m),
                new Menu("Fries", 2, ingredientList, "Fries", 0.99m),
            };
            _menuRepo.AddItems(menuList);
            _menuRepo.RemoveItem(2);
            menuList = _menuRepo.GetMenu();

            //--Act
            int actual = menuList.Count;
            int expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_SortedMenu_ShouldSortMenuByNumber()
        {
            //--Arrange
            MenuRepository _menuRepo = new MenuRepository();
            List<string> ingredientList = new List<string>();
            List<Menu> menuList = new List<Menu>()
            {
                new Menu("Burger", 2, ingredientList, "Borgor", 2.99m),
                new Menu("Fries", 1, ingredientList, "Fries", 0.99m),
            };
            _menuRepo.AddItems(menuList);

            List<Menu> sortedMenu = _menuRepo.SortedMenu();

            //--Act
            int actual = sortedMenu[0].MealNumber;
            int expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_GetMenu_ShouldReturnList()
        {
            //--Arrange
            MenuRepository _menuRepo = new MenuRepository();
            List<string> ingredientList = new List<string>();
            List<Menu> menuList = new List<Menu>()
            {
                new Menu("Burger", 2, ingredientList, "Borgor", 2.99m),
                new Menu("Fries", 1, ingredientList, "Fries", 0.99m),
            };
            _menuRepo.AddItems(menuList);

            List<Menu> sortedMenu = _menuRepo.SortedMenu();

            //--Act
            int actual = _menuRepo.GetMenu().Count;
            int expected = menuList.Count;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
