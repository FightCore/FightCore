using System.Collections.Generic;
using FightCore.Models.PlayerStatistics;
using FightCore.Models.Characters;
using System.Linq;
using FightCore.Services.Patterns;
using System.Threading.Tasks;

namespace FightCore.Services.PlayerStatistics
{
    /// <summary>
    /// Service for Metrics for players by character. <see cref="FightCore.Models.PlayerStatistics.CharacterPlayerStats"/>
    /// Current statistics are Win Loss Record with specified character and character usage out of total games played by player
    /// </summary>
    public interface ICharacterPlayerStatsService
    {
        CharacterPlayerStats GetCharacterPlayerStats(Player player, Character character, WinLossRecordService winLossRecordService);
    }

    public class CharacterPlayerStatsService : ICharacterPlayerStatsService
    {
        public CharacterPlayerStats GetCharacterPlayerStats(Player player, Character character, WinLossRecordService winLossRecordService)
        {
            CharacterPlayerStats stats = new CharacterPlayerStats(character);
            List<SetGame> setGames = new List<SetGame>();

            //Enumerate through player sets to retrieve set games
            foreach (Set set in player.Sets)
            {
                setGames.AddRange(set.Games);
            }

            stats.WinLossRecord = winLossRecordService.GetWinLossRecordByCharacter(player, character);

            // Total games played with character by player divivded by total games played by player = character usage
            stats.CharacterUsage =
                (decimal)setGames.Count(x =>
                (x.Character1 == character && x.Set.Player1Id == player.Id)
                || (x.Character2 == character && x.Set.Player2Id == player.Id))
                / (decimal)setGames.Count();

            return stats;
        }
    }
}
