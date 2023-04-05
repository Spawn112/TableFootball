namespace TableFootball.Interfaces
{
    using System.Collections.Generic;
    using TableFootball.Datatypes.Entities;

    public interface IMatchMovementService
    {
        IEnumerable<MatchMovement> AllMatchMovements();
        void Create(MatchMovement matchMovement);
    }
}