namespace TableFootball.Website.Models.Components.CreatePlayer
{
    public class CreatePlayerModel
    {
        public string Title { get; set; } = "Register Player";
        public string SubmitButton { get; set; } = "Submit";
        public string NameLabel { get; set; } = "Insert Name...";
        public string Name { get; set; }
        public string ErrorMsg { get; set; }
    }
}