using System;
using System.Collections.Generic;
using Challenge_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_2_Tests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        [TestMethod]
        public void ClaimRepository_AddToClaims_ShouldAddClaimToQueue()
        {
            //--Arrange
            ClaimRepository _claimRepo = new ClaimRepository();
            Claim claim = new Claim(1, ClaimTypes.Car, "Crash on 1st", 300.21m, _claimRepo.StringToDateTime("7/20/2018"), _claimRepo.StringToDateTime("7/30/2018"), true);
            _claimRepo.AddToClaims(claim);
            Queue<Claim> claims = _claimRepo.GetClaims();

            //--Act
            int actual = claims.Count;
            int expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimRepository_AddToClaimsList_ShouldAddClaimToQueue()
        {
            //--Arrange
            ClaimRepository _claimRepo = new ClaimRepository();
            Claim claim = new Claim(1, ClaimTypes.Car, "Crash on 1st", 300.21m, _claimRepo.StringToDateTime("7/20/2018"), _claimRepo.StringToDateTime("7/30/2018"), true);
            Claim claim2 = new Claim(2, ClaimTypes.Car, "Crash on 1st", 200.21m, _claimRepo.StringToDateTime("7/21/2018"), _claimRepo.StringToDateTime("7/31/2018"), true);
            List<Claim> claims = new List<Claim>();
            claims.Add(claim);
            claims.Add(claim2);
            _claimRepo.AddToClaims(claims);
            Queue<Claim> Claims = _claimRepo.GetClaims();

            //--Act
            int actual = Claims.Count;
            int expected = 2;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimRepository_RemoveClaim_ShoulRemoveClaimFromQueue()
        {
            //--Arrange
            ClaimRepository _claimRepo = new ClaimRepository();
            Claim claim = new Claim(1, ClaimTypes.Car, "Crash on 1st", 300.21m, _claimRepo.StringToDateTime("7/20/2018"), _claimRepo.StringToDateTime("7/30/2018"), true);
            _claimRepo.AddToClaims(claim);
            _claimRepo.RemoveClaim();
            Queue<Claim> claims = _claimRepo.GetClaims();


            //--Act
            int actual = claims.Count;
            int expected = 0;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimRepository_GetClaims_ShoulReturnList()
        {
            //--Arrange
            ClaimRepository _claimRepo = new ClaimRepository();
            Claim claim = new Claim(1, ClaimTypes.Car, "Crash on 1st", 300.21m, _claimRepo.StringToDateTime("7/20/2018"), _claimRepo.StringToDateTime("7/30/2018"), true);
            _claimRepo.AddToClaims(claim);
            Queue<Claim> claims = _claimRepo.GetClaims();


            //--Act
            int actual = claims.Count;
            int expected = _claimRepo.GetClaims().Count;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimRepository_StringToDate_ShoulReturnDateTime()
        {
            //--Arrange
            ClaimRepository _claimRepo = new ClaimRepository();

            DateTime date = _claimRepo.StringToDateTime("8/1/2018");


            //--Act
            int actual = date.Day;
            int expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
