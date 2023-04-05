namespace TableFootball.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TableFootball.Data.Enums;
    using TableFootball.Data.Interfaces;
    using TableFootball.Datatypes.Entities;
    using TableFootball.Interfaces;

    public class TrophyService : ITrophyService
    {
        private readonly ITrophyRepository _repository;
        public TrophyService(IFactory factory)
        {
            _repository = factory.GetTrophyRepository();
        }

        public IEnumerable<Trophy> AllTrophies()
        {
            var trophies = _repository.GetAll();
            if (!trophies.Any())
            {
                CreateTrophy(new Trophy() { ID = (int)Trophies.WinningStreak, Name = "Winning Streak", Players = new List<Guid>(), Value = 0 });
                CreateTrophy(new Trophy() { ID = (int)Trophies.LosingStreak, Name = "Losing Streak", Players = new List<Guid>(), Value = 0 });
                CreateTrophy(new Trophy() { ID = (int)Trophies.AllTimeHigh, Name = "All time High", Players = new List<Guid>(), Value = 1500 });
                CreateTrophy(new Trophy() { ID = (int)Trophies.AllTimeLow, Name = "All time Low", Players = new List<Guid>(), Value = 1500 });
            }
            return trophies;
        }

        public void CreateTrophy(Trophy trophy)
        {
            _repository.Create(trophy);
        }

        public Trophy GetTrophy(int id)
        {
            return _repository.GetTrophy(id);
        }

        public void UpdateTrophy(Trophy trophy)
        {
            _repository.UpdateTrophy(trophy);
        }

        public void HandleStreakTrophies(IEnumerable<Match> matches)
        {
            var allTrophies = AllTrophies();
            var winningStreakTrophy = allTrophies.First(t => t.ID == (int)Trophies.WinningStreak);
            var winningStreakUpdated = false;
            var losingStreakTrophy = allTrophies.First(t => t.ID == (int)Trophies.LosingStreak);
            var losingStreakUpdated = false;

            var playerResults = new Dictionary<Guid, List<bool>>();
            PreparePlayerResults(matches, playerResults);

            foreach (var player in playerResults.Keys)
            {
                var playerWinStreak = 0;
                var playerLoseStreak = 0;
                bool? lastGameWon = null;
                foreach (var game in playerResults[player])
                {
                    if (!lastGameWon.HasValue)
                    {
                        lastGameWon = HandleFirstGameOutcome(ref playerWinStreak, ref playerLoseStreak, game);
                    }
                    else
                    {
                        if (lastGameWon.Value)
                        {
                            HandleGameOutcome(winningStreakTrophy, ref winningStreakUpdated, player, ref playerWinStreak, ref playerLoseStreak, ref lastGameWon, game);
                        }
                        else
                        {
                            HandleGameOutcome(losingStreakTrophy, ref losingStreakUpdated, player, ref playerLoseStreak, ref playerWinStreak, ref lastGameWon, game);
                        }
                    }
                }
                UpdateStreakIfApplicable(winningStreakTrophy, ref winningStreakUpdated, player, playerWinStreak);
                UpdateStreakIfApplicable(losingStreakTrophy, ref losingStreakUpdated, player, playerLoseStreak);
            }
            if (winningStreakUpdated)
            {
                UpdateTrophy(winningStreakTrophy);
            }
            if (losingStreakUpdated)
            {
                UpdateTrophy(losingStreakTrophy);
            }
        }

        #region Service Methods
        private static bool HandleFirstGameOutcome(ref int playerWinStreak, ref int playerLoseStreak, bool gameWon)
        {
            if (gameWon)
            {
                playerWinStreak += 1;
            }
            else
            {
                playerLoseStreak += 1;
            }
            return gameWon;
        }

        private void HandleGameOutcome(Trophy streakTrophy, ref bool streakUpdated, Guid player, ref int playerStreak, ref int playerOppositeStreak, ref bool? lastGameWon, bool gameWon)
        {
            if (lastGameWon.Value != gameWon)
            {
                UpdateStreakIfApplicable(streakTrophy, ref streakUpdated, player, playerStreak);
                playerStreak = 0;
                playerOppositeStreak = 1;
                lastGameWon = gameWon;
            }
            else
            {
                playerStreak++;
            }
        }

        private void UpdateStreakIfApplicable(Trophy streakTrophy, ref bool streakUpdated, Guid player, int playerStreak)
        {
            if (playerStreak > streakTrophy.Value)
            {
                streakTrophy.Value = playerStreak;
                streakTrophy.Players = new List<Guid>() { player };
                streakUpdated = true;
            }
            else if (playerStreak == streakTrophy.Value)
            {
                if (!streakTrophy.Players.Contains(player))
                {
                    streakTrophy.Players = streakTrophy.Players.Concat(new List<Guid>() { player });
                    streakUpdated = true;
                }
            }
        }

        private void PreparePlayerResults(IEnumerable<Match> matches, Dictionary<Guid, List<bool>> playerResults)
        {
            foreach (var match in matches)
            {
                EnsurePlayerKeyIsInDictionary(playerResults, match);
                playerResults[match.Team1Player1].Add(match.Team1Score > match.Team2Score);
                playerResults[match.Team1Player2].Add(match.Team1Score > match.Team2Score);
                playerResults[match.Team2Player1].Add(match.Team1Score < match.Team2Score);
                playerResults[match.Team2Player2].Add(match.Team1Score < match.Team2Score);
            }
        }

        private void EnsurePlayerKeyIsInDictionary(Dictionary<Guid, List<bool>> playerResults, Match match)
        {
            if (!playerResults.ContainsKey(match.Team1Player1))
            {
                playerResults.Add(match.Team1Player1, new List<bool>());
            }
            if (!playerResults.ContainsKey(match.Team1Player2))
            {
                playerResults.Add(match.Team1Player2, new List<bool>());
            }
            if (!playerResults.ContainsKey(match.Team2Player1))
            {
                playerResults.Add(match.Team2Player1, new List<bool>());
            }
            if (!playerResults.ContainsKey(match.Team2Player2))
            {
                playerResults.Add(match.Team2Player2, new List<bool>());
            }
        }
        #endregion
    }
}