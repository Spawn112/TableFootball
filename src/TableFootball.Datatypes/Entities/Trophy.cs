namespace TableFootball.Datatypes.Entities
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson.Serialization.Attributes;

    public class Trophy
    {
        [BsonId]
        public Guid Guid { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Guid> Players { get; set; }
        public int Value { get; set; }
    }
}