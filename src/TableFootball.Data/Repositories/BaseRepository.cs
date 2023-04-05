namespace TableFootball.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using MongoDB.Driver;
    using TableFootball.Data.Interfaces;

    public abstract class BaseRepository<T> : IBaseRepository<T>
    {
        protected IMongoCollection<T> Collection { get; }
        private readonly string _mongoDBName = "TableFootball";
        private readonly static IMongoClient _mongoClient = new MongoClient();

        protected BaseRepository()
        {
            var mongoDatabase = _mongoClient.GetDatabase(_mongoDBName);
            Collection = mongoDatabase.GetCollection<T>(GetCollectionName());
        }

        public IEnumerable<T> GetAll()
        {
            var filter = FilterDefinition<T>.Empty;
            return Collection.Find(filter).ToList();
        }

        public void Create(T entity)
        {
            Collection.InsertOne(entity);
        }

        protected abstract string GetCollectionName();
    }
}