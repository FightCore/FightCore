using FightCore.Models.PlayerStatistics;

namespace FightCore.Services.PlayerStatistics
{
    public class HeadToHeadPlayerService
    {

        public static HeadToHeadPlayer GetHeadToHeadPlayer(Player player)
        {
            HeadToHeadPlayer headToHeadPlayer = new HeadToHeadPlayer();
            headToHeadPlayer.Id = player.Id;
            headToHeadPlayer.Sponsor = player.Sponsor;
            headToHeadPlayer.Name = player.Name;
            headToHeadPlayer.SmashggId = player.SmashggId;
            headToHeadPlayer.Media = player.Media;
            headToHeadPlayer.Sets = player.Sets;
            headToHeadPlayer.PlayerMetric = PlayerMetricService.GetPlayerMetric(player);
            return headToHeadPlayer;
        }

    }
}
