namespace TableFootball.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TableFootball.Data.Enums;
    using TableFootball.Datatypes.Entities;
    using TableFootball.Interfaces;

    public class CalculateRankService : ICalculateRankService
    {
        private readonly IPlayerService _playerService;
        private readonly ITrophyService _trophyService;
        private readonly IMatchMovementService _matchMovementService;

        public CalculateRankService(IFactory factory)
        {
            _playerService = factory.GetPlayerService();
            _trophyService = factory.GetTrophyService();
            _matchMovementService = factory.GetMatchMovementService();
        }

        public void UpdateRankings(IEnumerable<Player> team1, IEnumerable<Player> team2, GameOutcome outcome, Match match)
        {
            var team1PreUpdate = new List<Player>();
            foreach (var player in team1)
            {
                team1PreUpdate.Add(new Player() { Ranking = player.Ranking });
            }
            HandleOutcome(team1, team2, outcome == GameOutcome.Team1Win, match);
            foreach (var player in team1)
            {
                switch (outcome)
                {
                    case GameOutcome.Team1Win:
                        player.NumberOfWins += 1;
                        break;
                    case GameOutcome.Team2Win:
                        player.NumberOfLosses += 1;
                        break;
                    default:
                        break;
                }
                _playerService.UpdatePlayer(player);
                HandleTrophies(player);
            }

            HandleOutcome(team2, team1PreUpdate, outcome == GameOutcome.Team2Win, match);
            foreach (var player in team2)
            {
                switch (outcome)
                {
                    case GameOutcome.Team1Win:
                        player.NumberOfLosses += 1;
                        break;
                    case GameOutcome.Team2Win:
                        player.NumberOfWins += 1;
                        break;
                    default:
                        break;
                }
                _playerService.UpdatePlayer(player);
                HandleTrophies(player);
            }
        }

        #region Service Methods
        private void HandleTrophies(Player player)
        {
            var allTimeHigh = _trophyService.GetTrophy((int)Trophies.AllTimeHigh);
            var allTimeLow = _trophyService.GetTrophy((int)Trophies.AllTimeLow);
            if (player.Ranking > allTimeHigh.Value)
            {
                allTimeHigh.Value = player.Ranking;
                allTimeHigh.Players = new List<Guid>() { player.ID };
                _trophyService.UpdateTrophy(allTimeHigh);
            }
            else if (player.Ranking == allTimeHigh.Value)
            {
                allTimeHigh.Players = allTimeHigh.Players.Concat(new List<Guid>() { player.ID });
                _trophyService.UpdateTrophy(allTimeHigh);
            }
            else if (player.Ranking < allTimeLow.Value)
            {
                allTimeLow.Value = player.Ranking;
                allTimeLow.Players = new List<Guid>() { player.ID };
                _trophyService.UpdateTrophy(allTimeLow);
            }
            else if (player.Ranking == allTimeLow.Value)
            {
                allTimeLow.Players = allTimeLow.Players.Concat(new List<Guid>() { player.ID });
                _trophyService.UpdateTrophy(allTimeLow);
            }
        }

        private void HandleOutcome(IEnumerable<Player> teamToCalculate, IEnumerable<Player> opposingTeam, bool teamToCalculateWon, Match match)
        {
            foreach (var player in teamToCalculate)
            {
                var eloChange = 0.0;
                foreach (var opponent in opposingTeam)
                {
                    eloChange += CalculateELO(player.Ranking, opponent.Ranking, teamToCalculateWon ? 1 : 0);
                }
                var movement = (int)(eloChange / opposingTeam.Count());
                var matchMovement = new MatchMovement()
                {
                    GameWon = teamToCalculateWon,
                    PlayerID = player.ID,
                    Movement = movement > 0 ? movement : movement * -1,
                    MatchID = match.ID
                };
                _matchMovementService.Create(matchMovement);
                player.Ranking += movement;
            }
        }

        private static double CalculateELO(int playerOneRating, int playerTwoRating, int multiplier)
        {
            var eloK = 32;

            return (double)(eloK * (multiplier - ExpectationToWin(playerOneRating, playerTwoRating)));
        }

        private static double ExpectationToWin(double playerOneRating, double playerTwoRating)
        {
            return 1 / (1 + Math.Pow(10, (playerTwoRating - playerOneRating) / 400.0));
        }
        #endregion
    }
}