namespace TableFootball.Test
{
    using TableFootball.Data.Interfaces;
    using TableFootball.Interfaces;
    using TableFootball.Services;
    using TableFootball.Test.Fakes.Repositories;

    public class FakeFactory : IFactory
    {
        public ICalculateRankService GetCalculateRankService()
        {
            return new CalculateRankService(this);
        }

        private IMatchRepository _matchRepository;
        public IMatchRepository GetMatchRepository()
        {
            if (_matchRepository == null)
            {
                _matchRepository = new MatchRepositoryFake();
            }
            return _matchRepository;
        }

        private IPlayerRepository _playerRepository;
        public IPlayerRepository GetPlayerRepository()
        {
            if (_playerRepository == null)
            {
                _playerRepository = new PlayerRepositoryFake();
            }
            return _playerRepository;
        }

        public IPlayerService GetPlayerService()
        {
            return new PlayerService(this);
        }

        private ITrophyRepository _trophyRepository;
        public ITrophyRepository GetTrophyRepository()
        {
            if (_trophyRepository == null)
            {
                _trophyRepository = new TrophyRepositoryFake();
            }
            return _trophyRepository;
        }

        public ITrophyService GetTrophyService()
        {
            return new TrophyService(this);
        }

        private IMatchMovementRepository _matchMovementRepository;
        public IMatchMovementRepository GetMatchMovementRepository()
        {
            if (_matchMovementRepository == null)
            {
                _matchMovementRepository = new MatchMovementRepositoryFake();
            }
            return _matchMovementRepository;
        }

        public IMatchMovementService GetMatchMovementService()
        {
            return new MatchMovementService(this);
        }
    }
}