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
            SeedGreetings();
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
                        Console.ReadKey();
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
            List<Greetings> greetingsList = _repo.ReadListOfGreetings();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"        {halfDashes} Komodo Greetings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("                 All Greetings:\n" +
                $" {dashes}{dashes}{dashes}\n");

            Console.WriteLine("");

            foreach(var greeting in greetingsList)
            {
                Console.WriteLine($"First Name:{greeting.FirstName}");
                Console.WriteLine($"Last Name: {greeting.LastName}");
                Console.WriteLine($"Customer Type: {greeting.TypeOfCustomer}");
                Console.WriteLine($"Email Message: {greeting.Email}\n");
                Console.WriteLine("");
            }
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadKey();
            Menu();

        }

        private void CreateACustomer()
        {
            Greetings newGreeting = new Greetings();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"        {halfDashes} Komodo Greetings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("                Create A Greeting:\n" +
                $" {dashes}{dashes}{dashes}\n");

            Console.WriteLine("");
            Console.WriteLine("Enter the Customer's First Name:");

            string firstName = Console.ReadLine();
            newGreeting.FirstName = firstName;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"        {halfDashes} Komodo Greetings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("                Create A Greeting:\n" +
                $" {dashes}{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine($"Customer's First Name: {newGreeting.FirstName}");

            Console.WriteLine("");
            Console.WriteLine("Enter the Customer's Last Name:");

            string lastName = Console.ReadLine();
            newGreeting.LastName = lastName ;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"        {halfDashes} Komodo Greetings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("                Create A Greeting:\n" +
                $" {dashes}{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine($"Customer's First Name: {newGreeting.FirstName}");
            Console.WriteLine($"Customer's Last Name: {newGreeting.LastName}");

            Console.WriteLine("");
            Console.WriteLine("Enter the corresponding number for the customer's type:\n" +
                "\n" +
                "1: Potential\n" +
                "2: Current\n" +
                "3: Past\n");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    newGreeting.TypeOfCustomer = Greetings.TypeOfGreeting.Potential;
                    break;
                case "2":
                    newGreeting.TypeOfCustomer = Greetings.TypeOfGreeting.Current;
                    break;
                case "3":
                    newGreeting.TypeOfCustomer = Greetings.TypeOfGreeting.Past;
                    break;
                default:
                    Console.WriteLine("Please enter a valid customer type...");
                    break;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"        {halfDashes} Komodo Greetings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("                Create A Greeting:\n" +
                $" {dashes}{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine($"Customer's First Name: {newGreeting.FirstName}");
            Console.WriteLine($"Customer's Last Name: {newGreeting.LastName}");
            Console.WriteLine($"Customer Type: {newGreeting.TypeOfCustomer}");

            Console.WriteLine("");
            Console.WriteLine("Enter the Email Message:");

            string emailMessage = Console.ReadLine();
            newGreeting.Email = emailMessage;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"        {halfDashes} Komodo Greetings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("                Create A Greeting:\n" +
                $" {dashes}{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine($"Customer's First Name: {newGreeting.FirstName}");
            Console.WriteLine($"Customer's Last Name: {newGreeting.LastName}");
            Console.WriteLine($"Customer Type: {newGreeting.TypeOfCustomer}");
            Console.WriteLine($"Email Message: {newGreeting.Email}");

            Console.WriteLine("");
            Console.WriteLine("Are you sure you would like to add this customer? (y/n)");
            string input1 = Console.ReadLine().ToLower();

            switch (input1)
            {
                case "y":
                    Console.WriteLine("Customer and Message successfully added! You will now be returned to the Main Menu...");
                    _repo.CreateANewGreeting(newGreeting);
                    Console.ReadKey();
                    break;
                case "n":
                    Console.WriteLine("Customer and Message discarded... You will now be returned to the Main Menu...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Please enter either 'y' or 'n'");
                    break;
            }
            Menu();
        }

        private void UpdateACustomer()
        {
            throw new NotImplementedException();
        }

        private void DeleteACustomer()
        {
            throw new NotImplementedException();
        }
        public void SeedGreetings()
        {
            Greetings greeting1 = new Greetings("Scott", "Allen", Greetings.TypeOfGreeting.Potential, "Visit our website for a free quote today!");
            Greetings greeting2 = new Greetings("Sarah", "Smith", Greetings.TypeOfGreeting.Current, "Visit our website to see if you are eligible for our loyalty discount.");
            Greetings greeting3 = new Greetings("Caleb", "Wright", Greetings.TypeOfGreeting.Past, "We haven't heard from you in a while! Save 30% on your next purchase by using code KOMODO");
            Greetings greeting4 = new Greetings("Allen", "McCallum", Greetings.TypeOfGreeting.Potential, "If you are in the market for car insurance, visit komodoclaims.com for a free quote today!");
            Greetings greeting5 = new Greetings("Natalie", "Birch", Greetings.TypeOfGreeting.Past, "There are still items in your cart! Visit them here before their gone.");
            Greetings greeting6 = new Greetings("Scottie", "Schefler", Greetings.TypeOfGreeting.Current, "You've qualified for a continuing customer discount for your next purchase!");

            _repo.CreateANewGreeting(greeting1);
            _repo.CreateANewGreeting(greeting2);
            _repo.CreateANewGreeting(greeting3);
            _repo.CreateANewGreeting(greeting4);
            _repo.CreateANewGreeting(greeting5);
            _repo.CreateANewGreeting(greeting6);
        }
    }

}
