using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Models.PlayerStatistics;
using FightCore.Services.Patterns;

namespace FightCore.Services.PlayerStatistics
{
    /// <summary>
    /// Service for Head to Head calculations between players. <see cref="HeadToHead"/>
    /// Currently supports statistics on Win Loss Records between players.
    /// </summary>
    public interface IHeadToHeadService
    {
        HeadToHead GetHeadToHead(Player player1, Player player2, HeadToHeadPlayerService h2hPlayerService, 
            PlayerMetricService playerMetricService, CharacterPlayerStatsService characterPlayerStatsService, WinLossRecordService winLossRecordService);
    }

    public class HeadToHeadService : IHeadToHeadService
    {
        public HeadToHead GetHeadToHead(Player player1, Player player2, HeadToHeadPlayerService h2hPlayerService, 
            PlayerMetricService playerMetricService, CharacterPlayerStatsService characterPlayerStatsService, WinLossRecordService winLossRecordService)
        {
            HeadToHead headToHead = new HeadToHead
            (
                h2hPlayerService.GetHeadToHeadPlayer(player1, playerMetricService, characterPlayerStatsService, winLossRecordService),
                h2hPlayerService.GetHeadToHeadPlayer(player2, playerMetricService, characterPlayerStatsService, winLossRecordService), 
                new List<Set>()
            );

            // Get all sets from player1's list of sets that have the passed player1 and player2 as players.
            headToHead.Sets.AddRange(player1.Sets.Where(x =>
            (x.Player1.Id == player1.Id && x.Player2.Id == player2.Id)
            || (x.Player1.Id == player2.Id && x.Player2.Id == player1.Id)));

            // Assign number of set wins for Player 1 and Player 2 using established shared sets
            headToHead.Player1.SetWins = headToHead.Sets.Count(x => x.Winner.Id == player1.Id && x.Loser.Id == player2.Id);
            headToHead.Player2.SetWins = headToHead.Sets.Count(x => x.Winner.Id == player2.Id && x.Loser.Id == player1.Id);

            // Assign number of game wins for Player 1 and Player 2 using established shared games
            foreach (Set set in headToHead.Sets)
            {
                headToHead.Player1.GameWins += set.Games.Count(x => x.Winner == player1.Id && x.Loser == player2.Id);
                headToHead.Player2.GameWins += set.Games.Count(x => x.Winner == player2.Id && x.Loser == player1.Id);
            }

            return headToHead;
        }
    }
}
