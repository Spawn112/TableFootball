namespace TableFootball.Datatypes.Entities
{
    using System;

    public class MatchMovement
    {
        public Guid MatchID { get; set; }
        public Guid PlayerID { get; set; }
        public int Movement { get; set; }
        public bool GameWon { get; set; }
    }
}