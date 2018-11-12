using System.Collections.Generic;
using FightCore.Models.Characters;
using FightCore.Models.PlayerStatistics;

namespace FightCore.Services.PlayerStatistics
{
    public class PlayerMetricService
    {

        public static PlayerMetric GetPlayerMetric(Player player)
        {
            PlayerMetric metric = new PlayerMetric();
            metric.Player = player;
            metric.Characters = new List<Character>(); //Change to probably a service method for returning a result set of characters used by a given player
            metric.CharacterPlayerStats = new List<CharacterPlayerStats>();
            foreach (Character character in metric.Characters)
            {
                metric.CharacterPlayerStats.Add(CharacterPlayerStatsService.GetCharacterPlayerStats(player, character));
            }

            return metric;
        }

    }
}
