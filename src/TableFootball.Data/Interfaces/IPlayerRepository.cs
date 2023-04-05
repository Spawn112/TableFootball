namespace TableFootball.Data.Interfaces
{
    using TableFootball.Datatypes.Entities;

    public interface IPlayerRepository : IBaseRepository<Player>
    {
        void UpdatePlayer(Player player);
    }
}