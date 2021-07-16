using KomodoGreetings_POCOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoGreetings_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateAGreeting_ShoulodReturnTrue()
        {
            Greetings newGreeting = new Greetings("Todd", "Smith", Greetings.TypeOfGreeting.Current, "Use code KOMODO for 15% off your next month's deductible");
            GreetingsRepo _repo = new GreetingsRepo();

            bool isTrue = _repo.CreateANewGreeting(newGreeting);

            Assert.IsTrue(isTrue);

        }

        [TestMethod]
        public void CreateAGreeting_ShouldReturnFalse()
        {
            Greetings newGreeting = null;
            GreetingsRepo _repo = new GreetingsRepo();

            bool isFalse = _repo.CreateANewGreeting(newGreeting);

            Assert.IsFalse(isFalse);

        }

        [TestMethod]
        public void UpdateGreeting_ShouldReturnTrue()
        {
            Greetings newGreeting = new Greetings("Todd", "Smith", Greetings.TypeOfGreeting.Current, "Use code KOMODO for 15% off your next month's deductible");
            GreetingsRepo _repo = new GreetingsRepo();

            _repo.CreateANewGreeting(newGreeting);

            Greetings updatedGreeting = new Greetings("Todd", "Yarbrough", Greetings.TypeOfGreeting.Past, "We haven't heard from you in a bit, give us a call for a free quote today!");

            bool isTrue = _repo.UpdateGreeting(newGreeting, updatedGreeting);

            Assert.IsTrue(isTrue);

        }

        [TestMethod]
        public void UpdateGreeting_ShouldReturnNull()
        {
            Greetings newGreeting = new Greetings("Todd", "Smith", Greetings.TypeOfGreeting.Current, "Use code KOMODO for 15% off your next month's deductible");
            GreetingsRepo _repo = new GreetingsRepo();

            Greetings nullGreeting = new Greetings("Scott", "Swan", Greetings.TypeOfGreeting.Potential, "");

            _repo.CreateANewGreeting(newGreeting);

            Greetings updatedGreeting = new Greetings("Todd", "Yarbrough", Greetings.TypeOfGreeting.Past, "We haven't heard from you in a bit, give us a call for a free quote today!");

            bool isNull = _repo.UpdateGreeting(nullGreeting, updatedGreeting);

            Assert.IsFalse(isNull);

        }

        [TestMethod]
        public void DeleteAGreeting_ShouldReturnTrue()
        {
            Greetings newGreeting = new Greetings("Todd", "Smith", Greetings.TypeOfGreeting.Current, "Use code KOMODO for 15% off your next month's deductible");
            GreetingsRepo _repo = new GreetingsRepo();

            _repo.CreateANewGreeting(newGreeting);

            bool isTrue = _repo.DeleteAGreeting(newGreeting);

            Assert.IsTrue(isTrue);
        }

        [TestMethod]
        public void DeleteAGreeting_ShouldReturnFalse()
        {
            Greetings newGreeting = new Greetings("Todd", "Smith", Greetings.TypeOfGreeting.Current, "Use code KOMODO for 15% off your next month's deductible");
            GreetingsRepo _repo = new GreetingsRepo();

            Greetings nullGreeting = new Greetings("Scott", "Swan", Greetings.TypeOfGreeting.Potential, "");

            _repo.CreateANewGreeting(newGreeting);

            bool isFalse = _repo.DeleteAGreeting(nullGreeting);

            Assert.IsFalse(isFalse);
        }
    }
}
