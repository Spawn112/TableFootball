namespace TableFootball.Website.Models.Components.ScoreForm
{
    using System;
    using System.Collections.Generic;
    using TableFootball.Datatypes.Entities;

    public class ScoreFormModel
    {
        public string Title { get; set; } = "Register Match";
        public string SubmitButton { get; set; } = "Submit";
        public Guid Team1Player1 { get; set; }
        public Guid Team1Player2 { get; set; }
        public Guid Team2Player1 { get; set; }
        public Guid Team2Player2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public string WarningMsg { get; set; }
        public string ErrorMsg { get; set; }
    }
}