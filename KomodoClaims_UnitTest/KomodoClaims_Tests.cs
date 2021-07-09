using KomodoClaims_POCOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoClaims_UnitTest
{
    [TestClass]
    public class KomodoClaims_Tests
    {
        [TestMethod]
        public void CreateNewClaim()
        {
            //Arrange
            ClaimRepo _repo = new ClaimRepo();

            DateTime incidentDate = new DateTime(04 / 05 / 2021);
            DateTime claimDate = new DateTime(04 / 24 / 2021);
            Claim newClaim = new Claim(5, Claim.TypeOfClaim.Theft, "Stolen lawncare equipment", 500.69m, incidentDate, claimDate);

            Claim nullClaim = null;
            //Act

            bool claim = _repo.CreateClaim(newClaim);
            bool claimNull = _repo.CreateClaim(nullClaim);
            //Assert
            Assert.IsTrue(claim);
            Assert.IsFalse(claimNull);
        }

        [TestMethod]
        public void GetClaimByID()
        {
            //Arrange
            ClaimRepo _repo = new ClaimRepo();

            DateTime incidentDate = new DateTime(04 / 05 / 2021);
            DateTime claimDate = new DateTime(04 / 24 / 2021);
            Claim newClaim = new Claim(5, Claim.TypeOfClaim.Theft, "Stolen lawncare equipment", 500.69m, incidentDate, claimDate);
            Claim newerClaim = new Claim(7, Claim.TypeOfClaim.Theft, "Stolen lawncare equipment", 500.69m, incidentDate, claimDate);
            //Act
            _repo.CreateClaim(newClaim);
            Claim claim = _repo.GetClaimByID(5);

            //Assert
            Assert.AreEqual(claim, newClaim);
            Assert.AreNotEqual(claim, newerClaim);
        }

        [TestMethod]
        public void ViewAllClaimsInQueue()
        {
            //Arrange
            ClaimRepo _repo = new ClaimRepo();

            DateTime incidentDate = new DateTime(04 / 05 / 2021);
            DateTime claimDate = new DateTime(04 / 24 / 2021);
            Claim newClaim = new Claim(5, Claim.TypeOfClaim.Theft, "Stolen lawncare equipment", 500.69m, incidentDate, claimDate);
            Claim newerClaim = new Claim(7, Claim.TypeOfClaim.Theft, "Stolen lawncare equipment", 500.69m, incidentDate, claimDate);

            Queue<Claim> claims = new Queue<Claim>();
            claims.Enqueue(newClaim);
            claims.Enqueue(newerClaim);
            
            
            //Act
            _repo.CreateClaim(newClaim);
            _repo.CreateClaim(newerClaim);

             Queue<Claim> queueClaim = _repo.ViewAllClaims();

            //Assert
            Assert.IsNotNull(queueClaim);

        }
    }
}
