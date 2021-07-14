using KomodoBadges_POCOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadges_UnitTests
{

    [TestClass]

    public class UnitTest1
    {
        private readonly BadgesRepo _badgeRepo = new BadgesRepo();

        public Badges Arrange()
        {
            //Arrange 

            Badges badge = new Badges();

            List<string> doorNames = new List<string> { "A5", "A3" };

            badge.BadgeID = 5;
            badge.BadgeName = "Developers";
            badge.DoorNames = doorNames;

            return badge;

        }


        [TestMethod]
        public void TestMethod1()
        {
            //Arrange 
            Badges badge = Arrange();
            

            //Act
            bool createMethod = _badgeRepo.CreateABadge(badge);


            //Assert
            Assert.IsTrue(createMethod);
        }

        [TestMethod]
        public void ReadMethod()
        { 
            Dictionary<int, List<string>> returnedDictionary = _badgeRepo.ReadBadges();

            Assert.IsNotNull(returnedDictionary);
        }
        [TestMethod]
        public void UpdateDoor_ShouldReturnTrue()
        {


        }

        [TestMethod]
        public void DeleteDoors_ShouldReturnTrue()
        {
            //Arrange
            Badges badge = Arrange();
            _badgeRepo.CreateABadge(badge);

            //Act
           bool deleteDoor = _badgeRepo.DeleteDoorsOnExistingBadge(5, "A5");

            //Assert
            Assert.IsTrue(deleteDoor);

        }

        [TestMethod]
        public void DeleteDoor_DoorisNull_ShouldReturnFalse()
        {
            //Arrange
            Badges badge = Arrange();
            _badgeRepo.CreateABadge(badge);

            //Act
            bool deleteDoor = _badgeRepo.DeleteDoorsOnExistingBadge(6, "A5");

            //Assert
            Assert.IsFalse(deleteDoor);

        }



    }
}
