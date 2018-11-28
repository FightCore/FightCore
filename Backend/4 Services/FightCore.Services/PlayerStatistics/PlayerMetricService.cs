using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.Characters;
using FightCore.Models.PlayerStatistics;
using FightCore.Services.Patterns;
using System.Linq;

namespace FightCore.Services.PlayerStatistics
{
    /// <summary>
    /// Service for overall Metrics for players. <see cref="PlayerMetric"/>
    /// Currently supports statistics for characters used by player <see cref="CharacterPlayerStats"/>
    /// </summary>
    public interface IPlayerMetricService
    {
        PlayerMetric GetPlayerMetric(Player player, CharacterPlayerStatsService characterPlayerStatsService, WinLossRecordService winLossRecordService);
    }

    public class PlayerMetricService : IPlayerMetricService
    {
        public PlayerMetric GetPlayerMetric(Player player, CharacterPlayerStatsService characterPlayerStatsService, WinLossRecordService winLossRecordService)
        {
            PlayerMetric metric = new PlayerMetric(player, new List<Character>());
            List<SetGame> character1SetGameList = new List<SetGame>();
            List<SetGame> character2SetGameList = new List<SetGame>();
            List<int> characterIds;

            foreach (Set set in player.Sets)
            {
                if (set.Player1Id == player.Id) 
                    //Our player is Player 1
                    character1SetGameList.AddRange(set.Games);
                else
                    //Our player is Player 2
                    character2SetGameList.AddRange(set.Games);
            }

            //Add characters where our player is Player 1
            foreach (SetGame setGame in character1SetGameList)
            {
                metric.Characters.Add(setGame.Character1);
            }

            //Add characters where our player is Player 2
            foreach (SetGame setGame in character2SetGameList)
            {            
                metric.Characters.Add(setGame.Character2);
            }

            metric.CharacterPlayerStats = new List<CharacterPlayerStats>();
            characterIds = new List<int>();

            //Enumerate through the characters added above and create statistics for the given player for each character
            foreach (Character character in metric.Characters)
            {

                //Avoid making statistics for the same character more than once by using list of character ids.
                if (characterIds.Contains(character.Id))
                {
                    continue;
                }
                characterIds.Add(character.Id);
                metric.CharacterPlayerStats.Add(characterPlayerStatsService.GetCharacterPlayerStats(player, character, winLossRecordService));
            }

            return metric;
        }
    }
}
