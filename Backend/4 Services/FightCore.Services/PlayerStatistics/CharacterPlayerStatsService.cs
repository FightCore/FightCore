using System.Collections.Generic;
using FightCore.Models.PlayerStatistics;
using FightCore.Models.Characters;
using System.Linq;

namespace FightCore.Services.PlayerStatistics
{
    public class CharacterPlayerStatsService
    {

        public static CharacterPlayerStats GetCharacterPlayerStats(Player player, Character character)
        {
            CharacterPlayerStats stats = new CharacterPlayerStats();
            stats.Player = player;
            stats.Character = character;
            stats.Games = new List<SetGame>();
            foreach (Set set in player.Sets)
            {
                stats.Games.AddRange(set.Games);
            }
            // Total games won with character by player divivded by total games played with character by player = win percentage
            stats.WinPercentage =
                (decimal)stats.Games.Count(x =>
                x.Winner == player.Id &&
                ((x.Character1 == character && x.Set.Player1Id == player.Id)
                || (x.Character2 == character && x.Set.Player2Id == player.Id)))
                / (decimal)stats.Games.Count(x =>
                (x.Character1 == character && x.Set.Player1Id == player.Id)
                || (x.Character2 == character && x.Set.Player2Id == player.Id));
            // Total games played with character by player divivded by total games played by player = character usage
            stats.CharacterUsage =
                (decimal)stats.Games.Count(x =>
                (x.Character1 == character && x.Set.Player1Id == player.Id)
                || (x.Character2 == character && x.Set.Player2Id == player.Id))
                / (decimal)stats.Games.Count();

            return stats;
        }

    }
}
