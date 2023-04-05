namespace TableFootball.Interfaces
{
    using System.Collections.Generic;
    using TableFootball.Data.Enums;
    using TableFootball.Datatypes.Entities;

    public interface ICalculateRankService
    {
        void UpdateRankings(IEnumerable<Player> team1, IEnumerable<Player> team2, GameOutcome outcome, Match match);
    }
}