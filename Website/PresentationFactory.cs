namespace TableFootball.Website
{
    using TableFootball.Interfaces;
    using TableFootball.Services;

    public class PresentationFactory
    {
        public static IFactory Factory { get; set; } = new Factory();
        public static IMatchService MatchService { get; set; } = new MatchService(Factory);
        public static IPlayerService PlayerService { get; set; } = new PlayerService(Factory);
        public static ICalculateRankService CalculateRankService { get; set; } = new CalculateRankService(Factory);
        public static ITrophyService TrophyService { get; set; } = new TrophyService(Factory);
    }
}