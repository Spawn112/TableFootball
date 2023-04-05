namespace TableFootball.Website.Models.Components.Trophy
{
    using System.Collections.Generic;
    using TableFootball.Datatypes.Entities;

    public class TrophyModel
    {
        public string Name { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public int Value { get; set; }
    }
}