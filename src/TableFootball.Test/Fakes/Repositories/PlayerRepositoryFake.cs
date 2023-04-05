namespace TableFootball.Test.Fakes.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TableFootball.Data.Interfaces;
    using TableFootball.Datatypes.Entities;

    public class PlayerRepositoryFake : IPlayerRepository
    {
        public List<Player> Players { get; set; }

        public PlayerRepositoryFake()
        {
            //insert dummy data
            Players = new List<Player>()
            {
                new Player() { ID = new Guid("00000000-0000-0000-0000-000000000001"), Name = "Player#1", NumberOfLosses = 0, NumberOfWins = 0, Ranking = 1500 },
                new Player() { ID = new Guid("00000000-0000-0000-0000-000000000002"), Name = "Player#2", NumberOfLosses = 0, NumberOfWins = 0, Ranking = 1500 },
                new Player() { ID = new Guid("00000000-0000-0000-0000-000000000003"), Name = "Player#3", NumberOfLosses = 0, NumberOfWins = 0, Ranking = 1500 },
                new Player() { ID = new Guid("00000000-0000-0000-0000-000000000004"), Name = "Player#4", NumberOfLosses = 0, NumberOfWins = 0, Ranking = 1500 },
                new Player() { ID = new Guid("00000000-0000-0000-0000-000000000005"), Name = "Player#5", NumberOfLosses = 0, NumberOfWins = 0, Ranking = 1500 },
                new Player() { ID = new Guid("00000000-0000-0000-0000-000000000006"), Name = "Player#6", NumberOfLosses = 0, NumberOfWins = 0, Ranking = 1500 },
                new Player() { ID = new Guid("00000000-0000-0000-0000-000000000007"), Name = "Player#7", NumberOfLosses = 0, NumberOfWins = 0, Ranking = 1500 }
            };
        }

        public void Create(Player entity)
        {
            Players.Add(entity);
        }

        public IEnumerable<Player> GetAll()
        {
            return Players;
        }

        public void UpdatePlayer(Player player)
        {
            var existingPlayer = Players.FirstOrDefault(p => p.ID == player.ID);
            if (existingPlayer != null)
            {
                existingPlayer.Name = player.Name;
                existingPlayer.NumberOfLosses = player.NumberOfLosses;
                existingPlayer.NumberOfWins = player.NumberOfWins;
                existingPlayer.Ranking = player.Ranking;
            }
            else
            {
                Create(player);
            }
        }
    }
}