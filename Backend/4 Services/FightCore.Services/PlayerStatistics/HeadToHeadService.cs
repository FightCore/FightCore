using System.Collections.Generic;
using System.Linq;
using FightCore.Models.PlayerStatistics;

namespace FightCore.Services.PlayerStatistics
{
    public class HeadToHeadService
    {

        public static HeadToHead GetHeadToHead(Player player1, Player player2)
        {
            HeadToHead headToHead = new HeadToHead();
            headToHead.Player1 = HeadToHeadPlayerService.GetHeadToHeadPlayer(player1);
            headToHead.Player2 = HeadToHeadPlayerService.GetHeadToHeadPlayer(player2);
            headToHead.Sets = new List<Set>();
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
