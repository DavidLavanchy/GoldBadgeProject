using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings_POCOs
{
    public class Events
    {
        public enum TypeOfEvent { Golf, Bowling, AmusementPark, Concert }
        public Events(){}
        public Events(int numberOfPeople, DateTime dateOfEvent, TypeOfEvent eventType, decimal costPerPerson, decimal costPerEvent)
        {
            NumberOfPeople = numberOfPeople;
            DateOfEvent = dateOfEvent;
            Event = eventType;
            CostPerPerson = costPerPerson;
            CostPerEvent = costPerEvent;
        }

        public int NumberOfPeople { get; set; }
        public DateTime DateOfEvent { get; set; }
        public TypeOfEvent Event { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostPerEvent { get; set; }
    }
}
