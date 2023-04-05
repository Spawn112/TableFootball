namespace TableFootball
{
    using TableFootball.Data.Interfaces;
    using TableFootball.Data.Repositories;
    using TableFootball.Interfaces;
    using TableFootball.Services;

    public class Factory : IFactory
    {
        public ICalculateRankService GetCalculateRankService()
        {
            return new CalculateRankService(this);
        }

        public IMatchRepository GetMatchRepository()
        {
            return new MatchRepository();
        }

        public IMatchMovementRepository GetMatchMovementRepository()
        {
            return new MatchMovementRepository();
        }

        public IMatchMovementService GetMatchMovementService()
        {
            return new MatchMovementService(this);
        }

        public IPlayerRepository GetPlayerRepository()
        {
            return new PlayerRepository();
        }

        public IPlayerService GetPlayerService()
        {
            return new PlayerService(this);
        }

        public ITrophyRepository GetTrophyRepository()
        {
            return new TrophyRepository();
        }

        public ITrophyService GetTrophyService()
        {
            return new TrophyService(this);
        }
    }
}