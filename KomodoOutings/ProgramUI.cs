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
            SeedEvents();
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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Outings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Display Calculations:\n" +
                $"{dashes}{dashes}\n" +
                $"\n" +
                "          1. Combined Cost of All Outings\n" +
                "          2. Combined Cost of Outings By Event Type\n" +
                "          3. Return To Main Menu\n");
            Console.WriteLine($"{dashes}{dashes}");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CombinedCost();
                    break;
                case "2":
                    CombinedCostByEvent();
                    break;
                case "3":
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid menu option.");
                    break;
            }

        }

        private void CombinedCostByEvent()
        {
            throw new NotImplementedException();
        }

        public void CombinedCost()
        {
            List<Events> allEvents = _eventsRepo.ReadListOfEvents();

            decimal cost = default;

            //this logic iterates through the list of events and adds the total cost of all events within 365 calendar days of the current date
            foreach (var events in allEvents)
            {
                DateTime withinAYear = DateTime.Now.AddYears(-1);
                TimeSpan isValidTime = events.DateOfEvent.Date - withinAYear;
                if (isValidTime.TotalDays <= 365 && isValidTime.TotalDays >= 0)
                {
                    decimal costToBeAdded = events.CostPerEvent;
                    cost += costToBeAdded;
                }
            }


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {halfDashes} Komodo Outings {halfDashes}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("          Cost of All Events:\n" +
                $"{dashes}{dashes}\n");

            Console.WriteLine($"Total Cost of Events Within the Past Year: {cost}");
            Console.WriteLine("");
            Console.WriteLine($"Press any key to return to the Display Calculations Menu");

            Console.ReadKey();
            DisplayCalculations();

        }
        public void SeedEvents()
        {
            Events newEvent1 = new Events(25, DateTime.Parse("09/23/2020"), Events.TypeOfEvent.Bowling, 10m, 1000.67m);
            Events newEvent2 = new Events(50, DateTime.Parse("10/12/2020"), Events.TypeOfEvent.Concert, 25m, 2000.89m);
            Events newEvent3 = new Events(113, DateTime.Parse("04/07/2021"), Events.TypeOfEvent.Golf, 45.67m, 4789.90m);
            Events newEvent4 = new Events(500, DateTime.Parse("06/30/2021"), Events.TypeOfEvent.AmusementPark, 40.56m, 15693.98m);
            Events newEvent5 = new Events(49, DateTime.Parse("12/13/2020"), Events.TypeOfEvent.Bowling, 10m, 3456.78m);
            Events newEvent6 = new Events(87, DateTime.Parse("03/13/2020"), Events.TypeOfEvent.Bowling, 15.67m, 6446.78m);
            Events newEvent7 = new Events(200, DateTime.Parse("07/03/2021"), Events.TypeOfEvent.Golf, 50.55m, 10987.78m);
            Events newEvent8 = new Events(97, DateTime.Parse("07/13/2021"), Events.TypeOfEvent.Concert, 30m, 6750.09m);

            _eventsRepo.AddAnEvent(newEvent1);
            _eventsRepo.AddAnEvent(newEvent2);
            _eventsRepo.AddAnEvent(newEvent3);
            _eventsRepo.AddAnEvent(newEvent4);
            _eventsRepo.AddAnEvent(newEvent5);
            _eventsRepo.AddAnEvent(newEvent6);
            _eventsRepo.AddAnEvent(newEvent7);
            _eventsRepo.AddAnEvent(newEvent8);
        }
    }
}
