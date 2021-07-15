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
            SeedBadges();
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
                        EditABadge();
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

        private void EditABadge()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Edit a Badge:\n" +
                $"{dashes}{dashes}\n" +
                $"\n" +
                "          1. Add Doors on a Badge\n" +
                "          2. Delete Doors on a Badge\n" +
                "          3. Delete A Badge\n" +
                "          4. Exit To the Main Menu\n" +
                "\n" +
                $"{dashes}{dashes}");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddDoorsToABadge();
                    break;
                case "2":
                    RemoveADoorFromABadge();
                    break;
                case "3":
                    DeleteABadge();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid menu option.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private void AddDoorsToABadge()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Add a Door(s):\n");
            Console.WriteLine($"{ dashes}{ dashes}\n");
            Dictionary<int, List<string>> allBadges = _badgeRepo.ReadBadges();

            foreach (var kvp in allBadges)
            {
                Console.WriteLine($"Badge Number: {kvp.Key}");
                string badgeName = _badgeRepo.GetBadgeName(kvp.Key);
                Console.WriteLine($"Badge Name: {badgeName}");
                Console.WriteLine("Doors:");
                ViewEachDoorInBadge(kvp.Key);
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("Enter the ID of the Badge you wish to add a door(s) to:");

            int input = int.Parse(Console.ReadLine());

            AddBadge(input);
        }

        private void AddBadge(int input)
        {
            bool isTrue = true;

            Dictionary<int, List<string>> allBadges = _badgeRepo.ReadBadges();

            foreach (var kvp in allBadges)
            {
                if (input == kvp.Key)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("          Add a Door(s):\n");
                    Console.WriteLine("");
                    Console.WriteLine($"{ dashes}{ dashes}\n");
                    Console.WriteLine($"Badge Number: {kvp.Key}");
                    string badgeName = _badgeRepo.GetBadgeName(kvp.Key);
                    Console.WriteLine($"Badge Name: {badgeName}");
                    Console.WriteLine("Doors:");
                    ViewEachDoorInBadge(kvp.Key);
                    Console.WriteLine("Enter the door(s) you would like to add. You may enter multiple doors\n" +
                        "When you are finished entering doors type and enter '0'");
                }

                while (isTrue)
                {
                    string newDoors = Console.ReadLine();

                    if (newDoors != "0")
                    {
                        _badgeRepo.UpdateDoorsOnExistingBadge(input, newDoors);

                        foreach (var kvp2 in allBadges)
                        {
                            if (input == kvp2.Key)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
                                Console.ResetColor();
                                Console.WriteLine("");
                                Console.WriteLine("          Add a Door(s):\n");
                                Console.WriteLine("");
                                Console.WriteLine($"{ dashes}{ dashes}\n");
                                Console.WriteLine($"Badge Number: {kvp2.Key}");
                                string badgeName = _badgeRepo.GetBadgeName(kvp2.Key);
                                Console.WriteLine($"Badge Name: {badgeName}");
                                Console.WriteLine("Doors:");
                                ViewEachDoorInBadge(kvp2.Key);
                                Console.WriteLine("Enter the door(s) you would like to add. You may enter multiple doors\n" +
                                    "When you are finished entering doors type and enter '0'");
                            }
                        }
                    }
                    if (newDoors == "0")
                    {
                        _badgeRepo.DeleteDoorsOnExistingBadge(input, newDoors);
                        foreach (var kvp2 in allBadges)
                        {
                            if (input == kvp2.Key)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
                                Console.ResetColor();
                                Console.WriteLine("");
                                Console.WriteLine("          Add a Door(s):\n");
                                Console.WriteLine("");
                                Console.WriteLine($"{ dashes}{ dashes}\n");
                                Console.WriteLine($"Badge Number: {kvp2.Key}");
                                string badgeName = _badgeRepo.GetBadgeName(kvp2.Key);
                                Console.WriteLine($"Badge Name: {badgeName}");
                                Console.WriteLine("Doors:");
                                ViewEachDoorInBadge(kvp2.Key);
                                Console.WriteLine("Doors successfully added! You will now be returned to the Edit Badge Menu");
                                Console.ReadKey();
                            }
                        }
                        isTrue = false;
                    }


                }
                EditABadge();
            }
        }
        private void RemoveADoorFromABadge()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Delete a Door(s):\n");
            Console.WriteLine($"{ dashes}{ dashes}\n");
            Dictionary<int, List<string>> allBadges = _badgeRepo.ReadBadges();

            foreach (var kvp in allBadges)
            {
                Console.WriteLine($"Badge Number: {kvp.Key}");
                string badgeName = _badgeRepo.GetBadgeName(kvp.Key);
                Console.WriteLine($"Badge Name: {badgeName}");
                Console.WriteLine("Doors:");
                ViewEachDoorInBadge(kvp.Key);
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("Enter the ID of the Badge you wish to remove a door(s) from:");

            int input = int.Parse(Console.ReadLine());

            foreach (var kvp in allBadges)
            {
                if (input == kvp.Key)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("          Delete a Badge:\n");
                    Console.WriteLine("");
                    Console.WriteLine($"{ dashes}{ dashes}\n");
                    Console.WriteLine($"Badge Number: {kvp.Key}");
                    string badgeName = _badgeRepo.GetBadgeName(kvp.Key);
                    Console.WriteLine($"Badge Name: {badgeName}");
                    Console.WriteLine("Doors:");
                    ViewEachDoorInBadge(kvp.Key);
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("Select a Menu Option:");
            Console.WriteLine("");
            Console.WriteLine("1: Delete A Door On This Badge");
            Console.WriteLine("2: Delete All Door On This Badge");
            Console.WriteLine("3: Return to the Edit Badge Menu");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    RemoveDoor(input);
                    break;
                case "2":
                    RemoveAllDoors(input);
                    break;
                case "3":
                    Console.WriteLine("You will now be returned to the Edit Badge Menu...");
                    Console.ReadKey();
                    EditABadge();
                    break;
                default:
                    Console.WriteLine("Please enter a valid Menu Option");
                    break;
            }


        }

        private void RemoveAllDoors(int ID)
        {
            Dictionary<int, List<string>> allBadges = _badgeRepo.ReadBadges();

            foreach (var kvp in allBadges)
            {
                if (ID == kvp.Key)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("          Delete All Doors:\n");
                    Console.WriteLine("");
                    Console.WriteLine($"{ dashes}{ dashes}\n");
                    Console.WriteLine($"Badge Number: {kvp.Key}");
                    string badgeName = _badgeRepo.GetBadgeName(kvp.Key);
                    Console.WriteLine($"Badge Name: {badgeName}");
                    Console.WriteLine("Doors:");
                    ViewEachDoorInBadge(kvp.Key);
                    Console.WriteLine("");
                    Console.WriteLine("Are you sure you would like to delete all the doors on this badge? (y/n)");
                }
            }
            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "y":
                    _badgeRepo.DeleteAllDoorsOnExistingBadge(ID);
                    foreach (var kvp in allBadges)
                    {
                        if (ID == kvp.Key)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("          Delete All Doors:\n");
                            Console.WriteLine("");
                            Console.WriteLine($"{ dashes}{ dashes}\n");
                            Console.WriteLine($"Badge Number: {kvp.Key}");
                            string badgeName = _badgeRepo.GetBadgeName(kvp.Key);
                            Console.WriteLine($"Badge Name: {badgeName}");
                            Console.WriteLine("Doors:");
                            ViewEachDoorInBadge(kvp.Key);
                            Console.WriteLine("");
                            Console.WriteLine("Doors successfully deleted you will now be returned to the Edit Badge Menu");
                        }
                    }
                    Console.ReadKey();
                    EditABadge();
                    break;
                case "n":
                    foreach (var kvp in allBadges)
                    {
                        if (ID == kvp.Key)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("          Delete All Doors:\n");
                            Console.WriteLine("");
                            Console.WriteLine($"{ dashes}{ dashes}\n");
                            Console.WriteLine($"Badge Number: {kvp.Key}");
                            string badgeName = _badgeRepo.GetBadgeName(kvp.Key);
                            Console.WriteLine($"Badge Name: {badgeName}");
                            Console.WriteLine("Doors:");
                            ViewEachDoorInBadge(kvp.Key);
                            Console.WriteLine("");
                            Console.WriteLine("Doors were not deleted... you will now be returned to the Edit Badge Menu");
                        }
                    }
                    Console.ReadKey();
                    EditABadge();
                    break;
                default:
                    Console.WriteLine("Please enter a valid Menu Option... either 'y' or 'n'");
                    break;
            }

        }

        private void RemoveDoor(int ID)
        {
            bool isTrue = true;

            while (isTrue)
            {
                Dictionary<int, List<string>> allBadges = _badgeRepo.ReadBadges();

                string doorsToBeDeleted = Console.ReadLine();
                _badgeRepo.DeleteDoorsOnExistingBadge(ID, doorsToBeDeleted);

                foreach (var kvp in allBadges)
                {
                    if (ID == kvp.Key)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("          Delete a Badge:\n");
                        Console.WriteLine("");
                        Console.WriteLine($"{ dashes}{ dashes}\n");
                        Console.WriteLine($"Badge Number: {kvp.Key}");
                        string badgeName = _badgeRepo.GetBadgeName(kvp.Key);
                        Console.WriteLine($"Badge Name: {badgeName}");
                        Console.WriteLine("Doors:");
                        ViewEachDoorInBadge(kvp.Key);
                        Console.WriteLine("");
                        Console.WriteLine("Enter the door name that you would like to delete: You may enter multiple doornames\n" +
                        "When you are finished type and enter '0'");
                    }
                }
                if (doorsToBeDeleted == "0")
                {
                    Console.WriteLine("Doors successfully deleted! You will now be returned to the Edit Badge Menu.");
                    isTrue = false;
                }
            }

            EditABadge();
        }

        private void DeleteABadge()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Delete a Badge:\n");
            Console.WriteLine($"{ dashes}{ dashes}\n");
            Dictionary<int, List<string>> allBadges = _badgeRepo.ReadBadges();

            foreach (var kvp in allBadges)
            {
                Console.WriteLine($"Badge Number: {kvp.Key}");
                string badgeName = _badgeRepo.GetBadgeName(kvp.Key);
                Console.WriteLine($"Badge Name: {badgeName}");
                Console.WriteLine("Doors:");
                ViewEachDoorInBadge(kvp.Key);
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("Enter the ID of the Badge you wish to delete:");

            int input = int.Parse(Console.ReadLine());

            foreach (var kvp in allBadges)
            {
                if (input == kvp.Key)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("          Delete a Badge:\n");
                    Console.WriteLine("");
                    Console.WriteLine($"{ dashes}{ dashes}\n");
                    Console.WriteLine($"Badge Number: {kvp.Key}");
                    string badgeName = _badgeRepo.GetBadgeName(kvp.Key);
                    Console.WriteLine($"Badge Name: {badgeName}");
                    Console.WriteLine("Doors:");
                    ViewEachDoorInBadge(kvp.Key);
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("Are you sure you want to delete this badge? (y/n)");
            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "y":
                    _badgeRepo.DeleteAbadge(input);
                    Console.WriteLine("Badge successfully deleted... you will nowe be returned to the Edit Badge Menu...");
                    Console.ReadKey();
                    EditABadge();
                    break;
                case "n":
                    Console.WriteLine("Badge deletion abandonded... you will nowe be returned to the Edit Badge Menu...");
                    Console.ReadKey();
                    EditABadge();
                    break;
                default:
                    Console.WriteLine("Please enter a valid Menu option... either 'y or 'n");
                    break;
            }



        }

        private void ViewBadges()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Badges {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          View All Badges:\n");

            Dictionary<int, List<string>> allBadges = _badgeRepo.ReadBadges();

            foreach (var kvp in allBadges)
            {
                Console.WriteLine($"Badge Number: {kvp.Key}");
                string badgeName = _badgeRepo.GetBadgeName(kvp.Key);
                Console.WriteLine($"Badge Name: {badgeName}");
                Console.WriteLine("Doors:");
                ViewEachDoorInBadge(kvp.Key);
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadKey();
            Menu();
        }

        private void ViewEachDoorInBadge(int badgeID)
        {
            Dictionary<int, List<string>> doors = _badgeRepo.ReadBadges();

            foreach (var badge in doors)
            {
                if (badge.Key == badgeID)
                {
                    foreach (var value in badge.Value)
                    {
                        Console.WriteLine($"{value}");
                    }
                }
            }
        }

        public void SeedBadges()
        {
            List<string> badge1 = new List<string> { "A5", "A6", "A7" };
            List<string> badge2 = new List<string> { "B3", "B4" };
            List<string> badge3 = new List<string> { "C1", "C8", "C-N" };

            Badges badge11 = new Badges(5, badge1, "Developers");
            Badges badge22 = new Badges(6, badge2, "Security");
            Badges badge33 = new Badges(7, badge3, "Administration");

            _badgeRepo.CreateABadge(badge11);
            _badgeRepo.CreateABadge(badge22);
            _badgeRepo.CreateABadge(badge33);
        }
    }
}
