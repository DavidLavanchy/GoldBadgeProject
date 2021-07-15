using KomodoOutings_POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    class ProgramUI
    {
        string dashes = "--------------------";
        string halfDashes = "----------";

        private readonly EventsRepo _eventsRepo = new EventsRepo();
        public void Run()
        {
            Menu();
        }

        public void Menu()
        {
            bool isTrue = true;
            while (isTrue)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"    {halfDashes} Komodo Outings {halfDashes}");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("          Select a menu option:\n" +
                    $"{dashes}{dashes}\n" +
                    $"\n" +
                    "          1. Show All Outings\n" +
                    "          2. Add Outings To The List\n" +
                    "          3. Display Calculations\n" +
                    "          4. Exit This Application\n" +
                    "\n" +
                    $"{dashes}{dashes}");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        DisplayOutings();
                        break;
                    case "2":
                        AddOutingsToList();
                        break;
                    case "3":
                        DisplayCalculations();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        isTrue = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option.");
                        break;
                }
            }
        }

        private void DisplayOutings()
        {
            List<Events> allEvents = _eventsRepo.ReadListOfEvents();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Outings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          All Outings:\n" +
                $"{dashes}{dashes}\n");
            Console.WriteLine("");
            foreach(var events in allEvents)
            {
                Console.WriteLine($"Event Type: {events.Event}");
                Console.WriteLine($"Number of People at Event: {events.NumberOfPeople}");
                Console.WriteLine($"Date of Event: {events.DateOfEvent.ToString()}");
                Console.WriteLine($"Cost Per Person: {events.CostPerPerson}");
                Console.WriteLine($"Total Event Cost: {events.CostPerEvent}");
                Console.WriteLine("");
            }

            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadKey();
        }

        private void AddOutingsToList()
        {
            Events newEvent = new Events();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Outings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Add An Outing:\n" +
                $"{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine("Enter the corresponding number to what type of event you want the outing to be:\n" +
                "1: Golf\n" +
                "2: Bowling\n" +
                "3: Amusement Park\n" +
                "4: Concert\n");

            string eventTypeInput = Console.ReadLine();

            switch (eventTypeInput)
            {
                case "1":
                    newEvent.Event = Events.TypeOfEvent.Golf;
                    break;
                case "2":
                    newEvent.Event = Events.TypeOfEvent.Bowling;
                    break;
                case "3":
                    newEvent.Event = Events.TypeOfEvent.AmusementPark;
                    break;
                case "4":
                    newEvent.Event = Events.TypeOfEvent.Concert;
                    break;
                default:
                    Console.WriteLine("Please enter a valid event type option...");
                    break;
            }

            //Add the number of people to attend
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Outings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Add An Outing:\n" +
                $"{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine($"Event Type: {newEvent.Event}");
            Console.WriteLine("Enter the number of people who are going to be at the event: (i.e. 10, 50, 100)\n");

            int peopleInput = int.Parse(Console.ReadLine());
            newEvent.NumberOfPeople = peopleInput;

            //Add date of event
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Outings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Add An Outing:\n" +
                $"{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine($"Event Type: {newEvent.Event}");
            Console.WriteLine($"Number of People: {newEvent.NumberOfPeople}");
            Console.WriteLine("Enter the date of the event: (00/00/0000)\n");

            DateTime eventDate = DateTime.Parse(Console.ReadLine());
            newEvent.DateOfEvent = eventDate;

            //Add the cost per person
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Outings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Add An Outing:\n" +
                $"{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine($"Event Type: {newEvent.Event}");
            Console.WriteLine($"Number of People: {newEvent.NumberOfPeople}");
            Console.WriteLine($"Date of Event: {newEvent.DateOfEvent.Date.ToString("d")}");
            Console.WriteLine("Enter the cost per person:\n");

            decimal costPerPerson = decimal.Parse(Console.ReadLine());
            newEvent.CostPerPerson = costPerPerson;

            //Add cost for event
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Outings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Add An Outing:\n" +
                $"{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine($"Event Type: {newEvent.Event}");
            Console.WriteLine($"Number of People: {newEvent.NumberOfPeople}");
            Console.WriteLine($"Date of Event: {newEvent.DateOfEvent.Date.ToString("d")}");
            Console.WriteLine($"Cost per Person: {newEvent.CostPerPerson}");
            Console.WriteLine("Enter the cost for the event\n");

            decimal costForEvent = decimal.Parse(Console.ReadLine());
            newEvent.CostPerEvent = costForEvent;

            //prompt user to add or discard outing
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Outings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Add An Outing:\n" +
                $"{dashes}{dashes}\n");
            Console.WriteLine("");
            Console.WriteLine($"Event Type: {newEvent.Event}");
            Console.WriteLine($"Number of People: {newEvent.NumberOfPeople}");
            Console.WriteLine($"Date of Event: {newEvent.DateOfEvent.Date.ToString("d")}");
            Console.WriteLine($"Cost per Person: {newEvent.CostPerPerson}");
            Console.WriteLine($"Cost For the Event: {newEvent.CostPerEvent}");
            Console.WriteLine("");
            Console.WriteLine("Are you sure you would like to add this outing? (y/n)");

            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "y":
                    _eventsRepo.AddAnEvent(newEvent);
                    Console.WriteLine("Outing successfully added! You will now be returned to the Main Menu...");
                    Console.ReadKey();
                    Menu();
                    break;
                case "n":
                    Console.WriteLine("Outing discarded... You will now be returned to the Main Menu...");
                    Console.ReadKey();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid option... either 'y' or 'n'");
                    break;
            }
        }

        private void DisplayCalculations()
        {
            throw new NotImplementedException();
        }
    }
}
