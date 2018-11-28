using System.Collections.Generic;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    /// <summary>
    /// Service for Head to Head Player creation. <see cref="FightCore.Models.PlayerStatistics.HeadToHeadPlayer"/>
    /// Head to Head Players inherit Player class and have a PlayerMetrics object as an additional field
    /// </summary>
    public interface IHeadToHeadPlayerService
    {
        HeadToHeadPlayer GetHeadToHeadPlayer(Player player, PlayerMetricService playerMetricService, 
            CharacterPlayerStatsService characterPlayerStatsService, WinLossRecordService winLossRecordService);
    }

    public class HeadToHeadPlayerService : IHeadToHeadPlayerService
    {
        public HeadToHeadPlayer GetHeadToHeadPlayer(Player player, PlayerMetricService playerMetricService, 
            CharacterPlayerStatsService characterPlayerStatsService, WinLossRecordService winLossRecordService)
        {
            return new HeadToHeadPlayer(player, playerMetricService.GetPlayerMetric(player, characterPlayerStatsService, winLossRecordService));
        }
    }
}
