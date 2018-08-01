using System;
using System.Collections.Generic;
using Challenge_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_4_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        [TestMethod]
        public void BadgeRepository_NewBadge_ShouldAddBadgeToDictionary()
        {
            //--Arrange
            BadgeRepository _badgeRepo = new BadgeRepository();
            List<string> doors = new List<string>(new string[] { "A1", "A2" });
            Badge badge1 = new Badge(1001, doors);
            _badgeRepo.NewBadge(badge1);
            Dictionary<int, List<string>> badges = _badgeRepo.GetBadges();

            //--Act
            int actual = badges.Count;
            int expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BadgeRepository_NewBadgeList_ShouldAddBadgeToDictionary()
        {
            //--Arrange
            BadgeRepository _badgeRepo = new BadgeRepository();
            List<string> doors = new List<string>(new string[] { "A1", "A2" });
            Badge badge1 = new Badge(1001, doors);
            Badge badge2 = new Badge(1021, doors);
            List<Badge> badges = new List<Badge>();
            badges.Add(badge1);
            badges.Add(badge2);
            _badgeRepo.NewBadge(badges);
            Dictionary<int, List<string>> newBadges = _badgeRepo.GetBadges();

            //--Act
            int actual = newBadges.Count;
            int expected = 2;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BadgeRepository_GetBadges_ShouldReturnBadges()
        {
            //--Arrange
            BadgeRepository _badgeRepo = new BadgeRepository();

            //--Act
            int actual = _badgeRepo.GetBadges().Count;
            int expected = 0;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
