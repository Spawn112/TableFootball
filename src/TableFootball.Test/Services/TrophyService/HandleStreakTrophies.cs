namespace TableFootball.Test.Services.TrophyService
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TableFootball.Data.Enums;

    [TestClass]
    public class HandleStreakTrophies
    {
        [TestMethod]
        public void CheckWithDummyData()
        {
            //Arrange
            var factory = new FakeFactory();
            var service = factory.GetTrophyService();
            var allMatches = factory.GetMatchRepository().GetAll();

            //Act
            service.HandleStreakTrophies(allMatches);
            var trophies = factory.GetTrophyRepository().GetAll();
            var winningStreakTrophy = trophies.FirstOrDefault(t => t.ID == (int)Trophies.WinningStreak);
            var losingStreakTrophy = trophies.FirstOrDefault(t => t.ID == (int)Trophies.LosingStreak);

            //Assert
            Assert.AreEqual(winningStreakTrophy.Value, 2);
            Assert.AreEqual(winningStreakTrophy.Players.Count(), 1);
            Assert.AreEqual(winningStreakTrophy.Players.First(), new Guid("00000000-0000-0000-0000-000000000002"));
            Assert.AreEqual(losingStreakTrophy.Value, 2);
            Assert.AreEqual(losingStreakTrophy.Players.Count(), 2);
            Assert.IsTrue(losingStreakTrophy.Players.Contains(new Guid("00000000-0000-0000-0000-000000000001")));
            Assert.IsTrue(losingStreakTrophy.Players.Contains(new Guid("00000000-0000-0000-0000-000000000003")));
        }
    }
}