namespace TableFootball.Interfaces
{
    using System.Collections.Generic;
    using TableFootball.Datatypes.Entities;

    public interface ITrophyService
    {
        void UpdateTrophy(Trophy trophy);
        IEnumerable<Trophy> AllTrophies();
        void CreateTrophy(Trophy trophy);
        Trophy GetTrophy(int id);
        void HandleStreakTrophies(IEnumerable<Match> matches);
    }
}