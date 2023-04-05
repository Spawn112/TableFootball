namespace TableFootball.Test.Fakes.Repositories
{
    using System;
    using System.Collections.Generic;
    using TableFootball.Data.Interfaces;
    using TableFootball.Datatypes.Entities;

    public class MatchRepositoryFake : IMatchRepository
    {
        public List<Match> Matches { get; set; }

        public MatchRepositoryFake()
        {
            var players = new PlayerRepositoryFake().Players;
            //insert dummy data
            Matches = new List<Match>()
            {
                new Match(){ ID = new Guid("00000000-0000-0000-0001-000000000000"), Team1Player1 = players[0].ID, Team1Player2 = players[1].ID, Team1Score = 3, PlayedAt = DateTime.Parse("18-05-1984 15:15"), Team2Player1 = players[3].ID, Team2Player2 = players[4].ID, Team2Score = 10 },
                new Match(){ ID = new Guid("00000000-0000-0000-0002-000000000000"), Team1Player1 = players[1].ID, Team1Player2 = players[2].ID, Team1Score = 10, PlayedAt = DateTime.Parse("18-05-1984 15:16"), Team2Player1 = players[4].ID, Team2Player2 = players[5].ID, Team2Score = 5 },
                new Match(){ ID = new Guid("00000000-0000-0000-0003-000000000000"), Team1Player1 = players[2].ID, Team1Player2 = players[3].ID, Team1Score = 3, PlayedAt = DateTime.Parse("18-05-1984 15:17"), Team2Player1 = players[5].ID, Team2Player2 = players[6].ID, Team2Score = 10 },
                new Match(){ ID = new Guid("00000000-0000-0000-0004-000000000000"), Team1Player1 = players[3].ID, Team1Player2 = players[4].ID, Team1Score = 10, PlayedAt = DateTime.Parse("18-05-1984 15:18"), Team2Player1 = players[6].ID, Team2Player2 = players[0].ID, Team2Score = 5 },
                new Match(){ ID = new Guid("00000000-0000-0000-0005-000000000000"), Team1Player1 = players[4].ID, Team1Player2 = players[5].ID, Team1Score = 3, PlayedAt = DateTime.Parse("18-05-1984 15:19"), Team2Player1 = players[0].ID, Team2Player2 = players[1].ID, Team2Score = 10 },
                new Match(){ ID = new Guid("00000000-0000-0000-0006-000000000000"), Team1Player1 = players[5].ID, Team1Player2 = players[6].ID, Team1Score = 10, PlayedAt = DateTime.Parse("18-05-1984 15:20"), Team2Player1 = players[1].ID, Team2Player2 = players[2].ID, Team2Score = 5 }
            };
        }

        public void Create(Match entity)
        {
            Matches.Add(entity);
        }

        public IEnumerable<Match> GetAll()
        {
            return Matches;
        }
    }
}