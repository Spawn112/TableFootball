namespace TableFootball.Interfaces
{
    using System.Collections.Generic;
    using TableFootball.Datatypes.Entities;

    public interface IMatchService
    {
        void SubmitMatch(Match match);
        IEnumerable<Match> AllMatches();
    }
}