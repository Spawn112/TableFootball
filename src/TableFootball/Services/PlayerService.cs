namespace TableFootball.Services
{
    using System.Collections.Generic;
    using TableFootball.Data.Interfaces;
    using TableFootball.Datatypes.Entities;
    using TableFootball.Interfaces;

    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IFactory factory)
        {
            _playerRepository = factory.GetPlayerRepository();
        }

        public IEnumerable<Player> AllPlayers()
        {
            return _playerRepository.GetAll();
        }

        public void CreatePlayer(Player player)
        {
            _playerRepository.Create(player);
        }

        public void UpdatePlayer(Player player)
        {
            _playerRepository.UpdatePlayer(player);
        }
    }
}