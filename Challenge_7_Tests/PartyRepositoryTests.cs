using System;
using System.Collections.Generic;
using Challenge_7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_7_Tests
{
    [TestClass]
    public class PartyRepositoryTests
    {
        private PartyRepository _partyRepo = new PartyRepository();
         
        [TestMethod]
        public void PartyRepository_GerParties_ShouldGetPartyList()
        {
            //--Arrange
            List<Party> parties = _partyRepo.GetParties();

            //--Act
            int actual = parties.Count;
            int expected = 0;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartyRepository_AddParty_ShoulAddPartyToList()
        {
            //--Arrange
            _partyRepo.AddParty(new Party());

            List<Party> parties = _partyRepo.GetParties();


            //--Act
            int actual = parties.Count;
            int expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartyRepository_RemoveParty_ShoulRemovePartyFromList()
        {
            //--Arrange
            Party tempParty = new Party();
            _partyRepo.AddParty(tempParty);
            _partyRepo.RemoveParty(tempParty);
            List<Party> parties = _partyRepo.GetParties();


            //--Act
            int actual = parties.Count;
            int expected = 0;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
