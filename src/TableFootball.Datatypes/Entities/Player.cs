namespace TableFootball.Datatypes.Entities
{
    using System;
    using MongoDB.Bson.Serialization.Attributes;

    public class Player
    {
        [BsonId]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Ranking { get; set; }
        public int NumberOfWins { get; set; }
        public int NumberOfLosses { get; set; }

        public Player(string name)
        {
            ID = Guid.NewGuid();
            Name = name;
            Ranking = 1500;//hardcoded for now.
        }

        public Player() { }
    }
}