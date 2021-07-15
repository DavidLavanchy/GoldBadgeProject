using KomodoOutings_POCOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoOutings_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddEventShouldReturnTrue()
        {
            Events newEvent = new Events();
            EventsRepo _repo = new EventsRepo();

            newEvent.Event = Events.TypeOfEvent.Golf;
            newEvent.NumberOfPeople = 50;
            newEvent.CostPerPerson = 10m;
            newEvent.CostPerEvent = 3000m;
            newEvent.DateOfEvent = new DateTime(04 / 08 / 2021);

            bool isTrue = _repo.AddAnEvent(newEvent);

            Assert.IsTrue(isTrue);

        }
        [TestMethod]
        public void AddEventShouldReturnFalse()
        {
            Events newEvent = new Events();
            EventsRepo _repo = new EventsRepo();

            newEvent = null;

            bool isFalse = _repo.AddAnEvent(newEvent);

            Assert.IsFalse(isFalse);

        }

        [TestMethod]
        public void ReadList_ShouldReturn()
        {
            Events newEvent = new Events();
            EventsRepo _repo = new EventsRepo();

            newEvent.Event = Events.TypeOfEvent.Golf;
            newEvent.NumberOfPeople = 50;
            newEvent.CostPerPerson = 10m;
            newEvent.CostPerEvent = 3000m;
            newEvent.DateOfEvent = new DateTime(04 / 08 / 2021);

            _repo.AddAnEvent(newEvent);
            List<Events> eventList = _repo.ReadListOfEvents();

            Assert.IsNotNull(eventList);
        }
    }
}
