namespace TableFootball.Services
{
    using System.Collections.Generic;
    using TableFootball.Data.Interfaces;
    using TableFootball.Datatypes.Entities;
    using TableFootball.Interfaces;

    public class MatchMovementService : IMatchMovementService
    {
        private readonly IMatchMovementRepository _repository;

        public MatchMovementService(IFactory factory)
        {
            _repository = factory.GetMatchMovementRepository();
        }

        public IEnumerable<MatchMovement> AllMatchMovements()
        {
            return _repository.GetAll();
        }

        public void Create(MatchMovement matchMovement)
        {
            _repository.Create(matchMovement);
        }
    }
}