namespace TableFootball.Data.Repositories
{
    using System;
    using MongoDB.Driver;
    using TableFootball.Data.Interfaces;
    using TableFootball.Datatypes.Entities;

    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public void UpdatePlayer(Player player)
        {
            var filter = Builders<Player>.Filter.Where(p => p.ID == player.ID);
            var update = new UpdateDefinitionBuilder<Player>().Set(p => p.Name, player.Name).Set(p => p.Ranking, player.Ranking).Set(p => p.NumberOfLosses, player.NumberOfLosses).Set(p => p.NumberOfWins, player.NumberOfWins);
            var updateResult = Collection.UpdateOne(filter, update);
            if (!updateResult.IsAcknowledged)
            {
                throw new Exception("Couldn't update player!");
            };
        }

        protected override string GetCollectionName()
        {
            return "player";
        }
    }
}