namespace TableFootball.Test.Fakes.Repositories
{
    using System.Collections.Generic;
    using TableFootball.Data.Interfaces;
    using TableFootball.Datatypes.Entities;

    public class MatchMovementRepositoryFake : IMatchMovementRepository
    {
        public List<MatchMovement> MatchMovements { get; set; }

        public MatchMovementRepositoryFake()
        {
            MatchMovements = new List<MatchMovement>();
        }

        public void Create(MatchMovement entity)
        {
            MatchMovements.Add(entity);
        }

        public IEnumerable<MatchMovement> GetAll()
        {
            return MatchMovements;
        }
    }
}