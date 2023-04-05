namespace TableFootball.Data.Repositories
{
    using TableFootball.Data.Interfaces;
    using TableFootball.Datatypes.Entities;

    public class MatchRepository : BaseRepository<Match>, IMatchRepository
    {
        protected override string GetCollectionName()
        {
            return "match";
        }
    }
}