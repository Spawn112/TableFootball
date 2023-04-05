namespace TableFootball.Test.Services.CalculateRankService
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TableFootball.Data.Enums;

    [TestClass]
    public class UpdateRankings
    {
        [TestMethod]
        public void CheckTrophiesWithDummyData()
        {
            //Arrange
            var factory = new FakeFactory();
            var service = factory.GetCalculateRankService();
            var allMatches = factory.GetMatchRepository().GetAll().OrderBy(m => m.PlayedAt);
            var allPlayers = factory.GetPlayerRepository().GetAll();
            var allMovements = factory.GetMatchMovementRepository().GetAll();

            //Act
            foreach (var match in allMatches)
            {
                service.UpdateRankings(
                    allPlayers.Where(p => p.ID == match.Team1Player1 || p.ID == match.Team1Player2),
                    allPlayers.Where(p => p.ID == match.Team2Player1 || p.ID == match.Team2Player2),
                    match.Team1Score > match.Team2Score ? GameOutcome.Team1Win : GameOutcome.Team2Win,
                    match);
            }
            var trophies = factory.GetTrophyRepository().GetAll();
            var allHighTrophy = trophies.FirstOrDefault(t => t.ID == (int)Trophies.AllTimeHigh);
            var allLowTrophy = trophies.FirstOrDefault(t => t.ID == (int)Trophies.AllTimeLow);

            //Assert
            Assert.AreEqual(allHighTrophy.Value, 1517);
            Assert.AreEqual(allHighTrophy.Players.Count(), 1);
            Assert.AreEqual(allHighTrophy.Players.First(), new Guid("00000000-0000-0000-0000-000000000002"));
            Assert.AreEqual(allLowTrophy.Value, 1469);
            Assert.AreEqual(allLowTrophy.Players.Count(), 1);
            Assert.AreEqual(allLowTrophy.Players.First(), new Guid("00000000-0000-0000-0000-000000000001"));
        }
    }
}