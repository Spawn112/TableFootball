namespace TableFootball.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using TableFootball.Data.Enums;
    using TableFootball.Data.Interfaces;
    using TableFootball.Datatypes.Entities;
    using TableFootball.Interfaces;

    public class MatchService : IMatchService
    {
        private readonly IPlayerService _playerService;
        private readonly IMatchRepository _matchRepository;
        private readonly ICalculateRankService _calculateRank;
        private readonly ITrophyService _trophyService;

        public MatchService(IFactory factory)
        {
            _playerService = factory.GetPlayerService();
            _matchRepository = factory.GetMatchRepository();
            _calculateRank = factory.GetCalculateRankService();
            _trophyService = factory.GetTrophyService();
        }

        public IEnumerable<Match> AllMatches()
        {
            return _matchRepository.GetAll();
        }

        public void SubmitMatch(Match match)
        {
            SaveMatch(match);
            var allPlayers = _playerService.AllPlayers();
            var team1 = allPlayers.Where(p => p.ID == match.Team1Player1 || p.ID == match.Team1Player2);
            var team2 = allPlayers.Where(p => p.ID == match.Team2Player1 || p.ID == match.Team2Player2);
            _calculateRank.UpdateRankings(team1, team2, match.Team1Score > match.Team2Score ? GameOutcome.Team1Win : GameOutcome.Team2Win, match);
            _trophyService.HandleStreakTrophies(AllMatches());
        }

        private void SaveMatch(Match match)
        {
            _matchRepository.Create(match);
        }
    }
}
