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
        public void ReadOneBadge_ShouldReturnNotNull()
        {
            Badges badge = Arrange();
            _badgeRepo.CreateABadge(badge);

            //Act
            List<string> doors = _badgeRepo.ReadOneBadge(5);

            //Assert
            Assert.IsNotNull(doors);

        }

        [TestMethod]
        public void UpdateDoor_ShouldReturnTrue()
        {
            Badges badge = Arrange();
            _badgeRepo.CreateABadge(badge);

            bool isTrue = _badgeRepo.UpdateDoorsOnExistingBadge(5, "A6");

            Assert.IsTrue(isTrue);

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

        [TestMethod]
        public void DeleteAllDoors()
        {
            Badges badge = Arrange();
            _badgeRepo.CreateABadge(badge);

           bool isTrue = _badgeRepo.DeleteAllDoorsOnExistingBadge(5);

            Assert.IsTrue(isTrue);

        }

        [TestMethod]
        public void GetDoorName_ShouldReturnNotNull()
        {
            Badges badge = Arrange();
            _badgeRepo.CreateABadge(badge);

            string badgeName = _badgeRepo.GetBadgeName(5);

            Assert.AreEqual("Developers", badgeName);
        }

        [TestMethod]
        public void DeleteADoor_ShouldReturnTrue()
        {
            Badges badge = Arrange();
            _badgeRepo.CreateABadge(badge);

            bool isTrue = _badgeRepo.DeleteAbadge(5);

            Assert.IsTrue(isTrue);
        }


    }
}
