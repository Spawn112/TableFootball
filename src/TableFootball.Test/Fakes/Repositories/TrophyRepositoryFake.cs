namespace TableFootball.Test.Fakes.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TableFootball.Data.Enums;
    using TableFootball.Data.Interfaces;
    using TableFootball.Datatypes.Entities;

    public class TrophyRepositoryFake : ITrophyRepository
    {
        public List<Trophy> TrophyList { get; set; }

        public TrophyRepositoryFake()
        {
            TrophyList = new List<Trophy>()
            {
                new Trophy() { ID = (int)Trophies.WinningStreak, Name = "Winning Streak", Players = new List<Guid>(), Value = 0 },
                new Trophy() { ID = (int)Trophies.LosingStreak, Name = "Losing Streak", Players = new List<Guid>(), Value = 0 },
                new Trophy() { ID = (int)Trophies.AllTimeHigh, Name = "All time High", Players = new List<Guid>(), Value = 1500 },
                new Trophy() { ID = (int)Trophies.AllTimeLow, Name = "All time Low", Players = new List<Guid>(), Value = 1500 }
            };
        }

        public void Create(Trophy entity)
        {
            TrophyList.Add(entity);
        }

        public IEnumerable<Trophy> GetAll()
        {
            return TrophyList;
        }

        public Trophy GetTrophy(int id)
        {
            return TrophyList.FirstOrDefault(t => t.ID == id);
        }

        public void UpdateTrophy(Trophy trophy)
        {
            var existingTrophy = TrophyList.FirstOrDefault(p => p.ID == trophy.ID);
            if (existingTrophy != null)
            {
                TrophyList.Remove(existingTrophy);
            }
            Create(trophy);
        }
    }
}