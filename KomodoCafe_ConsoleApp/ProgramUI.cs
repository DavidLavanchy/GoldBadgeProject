using KomodoCafe_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_ConsoleApp
{
    public class ProgramUI
    {
        private string dashes = "--------------------";
        private string halfDashes = "----------";

        private MenuItems_Repo _menuItemsRepo = new MenuItems_Repo();

        public void Run()
        {


            Menu();
        }

        private void Menu()
        {
            bool isTrue = true;

            while (isTrue)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"    {halfDashes} Komodo Cafe {halfDashes}");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("          Select a menu option:\n" +
                    $"{dashes}{dashes}\n" +
                    $"\n" +
                    "          1. Add a Menu Item\n" +
                    "          2. Delete a Menu Item\n" +
                    "          3. View All Menu Items\n" +
                    "          4. Exit This Application\n" +
                    "\n" +
                    $"{dashes}{dashes}");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddAMenuItem();
                        break;
                    case "2":
                        DeleteAMenuItem();
                        break;
                    case "3":
                        ViewAMenuItem();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        isTrue = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddAMenuItem()
        {
            MenuItems menuItem = new MenuItems();

            // Meal Number
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Add A Menu Item {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Please Enter A Menu Item Number:\n" +
                $"{dashes}{dashes}\n");
            int mealID = int.Parse(Console.ReadLine());
            menuItem.MealNumber = mealID;

            // Meal Name
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Add A Menu Item {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Please Enter A Menu Item Name:\n" +
                $"{dashes}{dashes}\n" +
                $"\n" +
                $"Menu Item Number: {menuItem.MealNumber}");
            string mealName = Console.ReadLine();
            menuItem.MealName = mealName;

            // Meal Description
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Add A Menu Item {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Please Enter A Menu Item Description:\n" +
                $"{dashes}{dashes}\n" +
                $"\n" +
                $"Menu Item Number: {menuItem.MealNumber}\n" +
                $"Menu Item Name: {menuItem.MealName}");
            string mealDescription = Console.ReadLine();
            menuItem.MealDescription = mealDescription;

            // Meal Ingredients
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Add A Menu Item {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Please Enter Ingredients of the Menu Item:\n" +
                $"{dashes}{dashes}\n" +
                $"\n" +
                $"Menu Item Number: {menuItem.MealNumber}\n" +
                $"Menu Item Name: {menuItem.MealName}\n" +
                $"Menu Item Description: {menuItem.MealDescription}");

            Console.WriteLine("");
            Console.WriteLine("Type in an ingredient and then press enter. Enter as many as you see fit.");
            Console.WriteLine("");
            Console.WriteLine("If you are done entering ingredients, then enter '1'. ");

            List<string> ingredients = new List<string>();

            bool isTrue = true;
            while (isTrue)
            {
                
                string ingredient = Console.ReadLine();
                ingredients.Add(ingredient);

                if(ingredient == "1")
                {
                    ingredients.Remove(ingredient);
                    isTrue = false;
                }
                else
                {
                    isTrue = true;
                }
            }
            menuItem.MealIngredients = ingredients;

            // Meal Price
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Add A Menu Item {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Please Enter A Price for the Menu Item:\n" +
                $"{dashes}{dashes}\n" +
                $"\n" +
                $"Menu Item Number: {menuItem.MealNumber}\n" +
                $"Menu Item Name: {menuItem.MealName}\n" +
                $"Menu Item Description: {menuItem.MealDescription}\n" +
                $"Menu Item Ingredients:"); DisplayEachIngredientFromMenuItem(menuItem);

            decimal mealPrice = Decimal.Parse(Console.ReadLine());
            menuItem.MealPrice = mealPrice;

            // Are you sure you want to add this Menu Item
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Add A Menu Item {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("Are you sure you want to add this Menu Item (y/n):\n" +
                $"{dashes}{dashes}\n" +
                $"\n" +
                $"Menu Item Number: {menuItem.MealNumber}\n" +
                $"Menu Item Name: {menuItem.MealName}\n" +
                $"Menu Item Description: {menuItem.MealDescription}\n" +
                $"Menu Item Ingredients:");DisplayEachIngredientFromMenuItem(menuItem);
            Console.WriteLine($"Menu Price: {menuItem.MealPrice}\n");

            string input = Console.ReadLine();

            switch (input)
            {
                case "y":
                    _menuItemsRepo.CreateMenuItem(menuItem);
                    Console.WriteLine("Menu Item Successfully Added!");
                    break;
                case "n":
                    Console.WriteLine("You will now be returned to the main menu. Press any keyt to continue...");
                    Console.ReadKey();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please enter either 'y' or 'n'. Enter 'y' if you would like to go forward with adding this new Menu Item.\n" +
                        "" +
                        "Enter 'n' if you would like to abandon this Menu Item.");
                    break;
            }

        }

        private void DeleteAMenuItem()
        {
            
        }

        private void ViewAMenuItem()
        {
            throw new NotImplementedException();
        }

        private void DisplayEachIngredientFromMenuItem(MenuItems menuItem)
        {
            foreach(var item in menuItem.MealIngredients)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
