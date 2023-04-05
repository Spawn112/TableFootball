namespace TableFootball.Datatypes.Entities
{
    using System;
    using MongoDB.Bson.Serialization.Attributes;

    public class Match
    {
        [BsonId]
        public Guid ID { get; set; }
        public Guid Team1Player1 { get; set; }
        public Guid Team1Player2 { get; set; }
        public Guid Team2Player1 { get; set; }
        public Guid Team2Player2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public DateTime PlayedAt { get; set; }
    }
}