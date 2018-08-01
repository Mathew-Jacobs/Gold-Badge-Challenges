using System;
using System.Collections.Generic;
using Challenge_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_3_Tests
{
    [TestClass]
    public class OutingTests
    {
        [TestMethod]
        public void OutingRepository_AddOutingsList_ShouldReturnList()
        {
            //--Arrange
            OutingRepository _outingRepo = new OutingRepository();
            Outing outing1 = new Outing(EventTypes.Bowling, 30, _outingRepo.StringToDateTime("7/20/2017"), 1000.40m);
            Outing outing2 = new Outing(EventTypes.Concert, 10, _outingRepo.StringToDateTime("7/20/2017"), 100.40m);
            List<Outing> expectedoutings = new List<Outing>();
            expectedoutings.Add(outing1);
            expectedoutings.Add(outing2);
            _outingRepo.AddOutings(expectedoutings);
            List<Outing> outings = _outingRepo.GetOutings();

            //--Act
            int actual = outings.Count;
            int expected = 2;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepository_AddOuting_ShouldReturnList()
        {
            //--Arrange
            OutingRepository _outingRepo = new OutingRepository();
            Outing outing1 = new Outing(EventTypes.Bowling, 30, _outingRepo.StringToDateTime("7/20/2017"), 1000.40m);
            _outingRepo.AddOutings(outing1);
            List<Outing> outings = _outingRepo.GetOutings();

            //--Act
            int actual = outings.Count;
            int expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepository_GetOutings_ShouldReturnList()
        {
            //--Arrange
            OutingRepository _outingRepo = new OutingRepository();
            Outing outing1 = new Outing(EventTypes.Bowling, 30, _outingRepo.StringToDateTime("7/20/2017"), 1000.40m);
            Outing outing2 = new Outing(EventTypes.Concert, 10, _outingRepo.StringToDateTime("7/20/2017"), 100.40m);
            List<Outing> expectedoutings = new List<Outing>();
            expectedoutings.Add(outing1);
            expectedoutings.Add(outing2);
            _outingRepo.AddOutings(expectedoutings);

            //--Act
            int actual = _outingRepo.GetOutings().Count;
            int expected = 2;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepository_TotalCost_ShouldBeSumOfCosts()
        {
            //--Arrange
            OutingRepository _outingRepo = new OutingRepository();
            Outing outing1 = new Outing(EventTypes.Bowling, 30, _outingRepo.StringToDateTime("7/20/2017"), 1000.40m);
            Outing outing2 = new Outing(EventTypes.Concert, 10, _outingRepo.StringToDateTime("7/20/2017"), 100.40m);
            List<Outing> outings = new List<Outing>();
            outings.Add(outing1);
            outings.Add(outing2);

            //--Act
            decimal actual = _outingRepo.TotalCost(outings);
            decimal expected = 1100.80m;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepository_TotalCostByType_ShouldBeSumOfCosts()
        {
            //--Arrange
            OutingRepository _outingRepo = new OutingRepository();
            Outing outing1 = new Outing(EventTypes.Bowling, 30, _outingRepo.StringToDateTime("7/20/2017"), 1000.40m);
            Outing outing2 = new Outing(EventTypes.Concert, 10, _outingRepo.StringToDateTime("7/20/2017"), 100.40m);
            List<Outing> outings = new List<Outing>();
            outings.Add(outing1);
            outings.Add(outing2);

            //--Act
            decimal actual = _outingRepo.TotalCostByType(outings, EventTypes.Bowling);
            decimal expected = 1000.40m;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepository_StringToDateTime_ShoulReturnDateTime()
        {
            //--Arrange
            OutingRepository _outingRepo = new OutingRepository();

            DateTime date = _outingRepo.StringToDateTime("8/1/2018");


            //--Act
            int actual = date.Day;
            int expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
