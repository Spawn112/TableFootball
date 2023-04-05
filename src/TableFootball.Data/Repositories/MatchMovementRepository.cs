namespace TableFootball.Data.Repositories
{
    using TableFootball.Data.Interfaces;
    using TableFootball.Datatypes.Entities;

    public class MatchMovementRepository : BaseRepository<MatchMovement>, IMatchMovementRepository
    {
        protected override string GetCollectionName()
        {
            return "matchMovement";
        }
    }
}