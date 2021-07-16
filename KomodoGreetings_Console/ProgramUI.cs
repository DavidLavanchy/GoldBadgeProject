using KomodoGreetings_POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreetings_Console
{
    public class ProgramUI
    {
        GreetingsRepo _repo = new GreetingsRepo();

        private string dashes = "--------------------";
        private string halfDashes = "----------";

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool isTrue = true;

            while (isTrue)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"        {halfDashes} Komodo Greetings! {halfDashes}");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("                 Select a menu option:\n" +
                    $" {dashes}{dashes}{dashes}\n" +
                    $"\n" +
                    "          1. See All Customers and Connected Greetings\n" +
                    "          2. Create A Customer\n" +
                    "          3. Update A Customer\n" +
                    "          4. Delete A Customer\n" +
                    "          5. Exit This Application\n" +
                    "\n" +
                    $" {dashes}{dashes}{dashes}");

                Console.WriteLine("          An application built by Komodo Greetings");
                Console.WriteLine("          Enterprises to help businesses of all sizes");
                Console.WriteLine("          manage their email subscription lists...");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllCustomers();
                        break;
                    case "2":
                        CreateACustomer();
                        break;
                    case "3":
                        UpdateACustomer();
                        break;
                    case "4":
                        DeleteACustomer();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye! You will now exit this application");
                        isTrue = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option...");
                        break;
                }
            }
        }

        private void ViewAllCustomers()
        {
            throw new NotImplementedException();
        }

        private void CreateACustomer()
        {
            throw new NotImplementedException();
        }

        private void UpdateACustomer()
        {
            throw new NotImplementedException();
        }

        private void DeleteACustomer()
        {
            throw new NotImplementedException();
        }
    }

}
