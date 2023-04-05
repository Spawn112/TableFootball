namespace TableFootball.Interfaces
{
    using System.Collections.Generic;
    using TableFootball.Datatypes.Entities;

    public interface IPlayerService
    {
        IEnumerable<Player> AllPlayers();
        void CreatePlayer(Player player);
        void UpdatePlayer(Player player);
    }
}