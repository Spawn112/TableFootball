namespace TableFootball.Data.Repositories
{
    using System;
    using MongoDB.Driver;
    using TableFootball.Data.Interfaces;
    using TableFootball.Datatypes.Entities;

    public class TrophyRepository : BaseRepository<Trophy>, ITrophyRepository
    {
        public Trophy GetTrophy(int id)
        {
            var filter = Builders<Trophy>.Filter.Where(p => p.ID == id);
            return Collection.Find(filter).FirstOrDefault();
        }

        public void UpdateTrophy(Trophy trophy)
        {
            var filter = Builders<Trophy>.Filter.Where(p => p.ID == trophy.ID);
            var update = new UpdateDefinitionBuilder<Trophy>().Set(t => t.Players, trophy.Players).Set(t => t.Value, trophy.Value);
            var updateResult = Collection.UpdateOne(filter, update);
            if (!updateResult.IsAcknowledged)
            {
                throw new Exception("Couldn't update trophy!");
            };
        }

        protected override string GetCollectionName()
        {
            return "Trophy";
        }
    }
}