namespace TableFootball.Data.Interfaces
{
    using TableFootball.Datatypes.Entities;

    public interface ITrophyRepository : IBaseRepository<Trophy>
    {
        void UpdateTrophy(Trophy trophy);
        Trophy GetTrophy(int id);
    }
}