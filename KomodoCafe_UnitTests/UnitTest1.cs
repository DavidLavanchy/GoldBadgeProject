using KomodoCafe_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafe_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldAddMenuItem()
        {
            //Arrange
            List<string> _ingredients = new List<string>();
            _ingredients.Add("pickles");
            _ingredients.Add("bun");
            _ingredients.Add("patty");
            MenuItems menuItem = new MenuItems(5, "bigMac", "Big Mac sandwich, fries, and a drink", _ingredients , 8.50m);
            MenuItems_Repo _repo = new MenuItems_Repo();

            //Act
            _repo.CreateMenuItem(menuItem);
            MenuItems newItem = _repo.GetMenuItemByID(5);

            //Assert
            Assert.IsNotNull(newItem);
        }

        [TestMethod]
        public void DeleteFromList_ShouldReturnTrue()
        {
            //Arrange
            List<string> _ingredients = new List<string>();
            _ingredients.Add("pickles");
            _ingredients.Add("bun");
            _ingredients.Add("patty");
            MenuItems menuItem = new MenuItems(5, "bigMac", "Big Mac sandwich, fries, and a drink", _ingredients, 8.50m);
            MenuItems_Repo _repo = new MenuItems_Repo();

            _repo.CreateMenuItem(menuItem);

            //Act
            bool deleteResult = _repo.DeleteItemFromList(5);

            //Assert
            Assert.IsTrue(deleteResult);

        }

        [TestMethod]
        public void ReturnListOfMenuItems()
        {
            //Arrange
            List<string> _ingredients = new List<string>();
            _ingredients.Add("pickles");
            _ingredients.Add("bun");
            _ingredients.Add("patty");
            MenuItems menuItem = new MenuItems(5, "bigMac", "Big Mac sandwich, fries, and a drink", _ingredients, 8.50m);
            MenuItems_Repo _repo = new MenuItems_Repo();

            //Act
            _repo.CreateMenuItem(menuItem);
            List<MenuItems> newList = _repo.ReadMenuItems();

            //Assert
            Assert.IsNotNull(newList);
        }

    }
}
