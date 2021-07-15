using KomodoBadges_POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Console
{
    public class ProgramUI
    {
        BadgesRepo _badgeRepo = new BadgesRepo();

        string dashes = "--------------------";
        string halfDashes = "----------";
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
                Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("          Select a menu option:\n" +
                    $"{dashes}{dashes}\n" +
                    $"\n" +
                    "          1. Add a Badge\n" +
                    "          2. Edit a Badge\n" +
                    "          3. View All Badges\n" +
                    "          4. Exit This Application\n" +
                    "\n" +
                    $"{dashes}{dashes}");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        DeleteABadge();
                        break;
                    case "3":
                        ViewBadges();
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

        private void AddABadge()
        {
            Badges newBadge = new Badges();
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Add a Badge:\n" +
                $"{dashes}{dashes}\n");

            Console.WriteLine("Add a Name for this badge:");

            string badgeName = Console.ReadLine();
            newBadge.BadgeName = badgeName;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Add a Badge:\n" +
                $"{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine($"Badge Name: {newBadge.BadgeName}");
            Console.WriteLine("");
            Console.WriteLine("Add a Number for this badge:");
            int badgeNumber = int.Parse(Console.ReadLine());

            newBadge.BadgeID = badgeNumber;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Add a Badge:\n" +
                $"{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine($"Badge Name: {newBadge.BadgeName}");
            Console.WriteLine($"Badge Number: {newBadge.BadgeID}");
            Console.WriteLine("");
            Console.WriteLine("Add a Door(s) for this badge. When you are finished adding doors type '0' and press enter:");

            List<string> doors = new List<string>(0);

            bool addingDoors = true;
            while (addingDoors)
            {
                string badgeDoors = Console.ReadLine();
                doors.Add(badgeDoors);

                if (badgeDoors == "0")
                {
                    doors.Remove(badgeDoors);
                    addingDoors = false;
                }
            }

            newBadge.DoorNames = doors;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Add a Badge:\n" +
                $"{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine($"Badge Name: {newBadge.BadgeName}");
            Console.WriteLine($"Badge Number: {newBadge.BadgeID}");
            foreach (var badge in doors)
            {
                Console.WriteLine($"{badge}");
            }
            Console.WriteLine("");
            Console.WriteLine("Are you sure you want to add this badge (y/n):");

            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "y":
                    _badgeRepo.CreateABadge(newBadge);
                    Console.WriteLine("Badge Successfully Added...you will now be returned to the main menu...");
                    Console.ReadKey();
                    Menu();
                    break;
                case "n":
                    Console.WriteLine("Badge Discarded...you will now be returned to the main menu...");
                    Console.ReadKey();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid Menu Option... either 'y or 'n");
                    break;
            }

        }

        private void DeleteABadge()
        {
            throw new NotImplementedException();
        }

        private void ViewBadges()
        {
            throw new NotImplementedException();
        }

        private void ViewEachDoorInBadge(int badgeID)
        {
            Dictionary<int, List<string>> doors = _badgeRepo.ReadBadges();

            foreach (var badge in doors)
            {
                if(badge.Key == badgeID)
                {
                    foreach(var value in badge.Value)
                    {
                        Console.WriteLine($"{value}");
                    }
                }
            }
        }
    }
}
