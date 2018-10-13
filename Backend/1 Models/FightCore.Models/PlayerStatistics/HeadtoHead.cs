using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FightCore.Models;
using FightCore.Models.Characters;
using FightCore.Models.Shared;

namespace FightCore.Models.PlayerStatistics
{
    public class HeadtoHead
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public PlayerMetrics Player1Metrics { get; set; }
        public PlayerMetrics Player2Metrics { get; set; }
        public List<Set> Sets { get; set; }
        public int Player1SetWins { get; set; }
        public int Player2SetWins { get; set; }
        public int Player1GameWins { get; set; }
        public int Player2GameWins { get; set; }

        public HeadtoHead(Player player1, Player player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            this.Player1Metrics = new PlayerMetrics(player1);
            this.Player2Metrics = new PlayerMetrics(player2);
            this.Sets = new List<Set>();
            /// <summary>
            /// Get all sets from player1's list of sets that have the passed player1 and player2 as players.
            /// </summary>
            this.Sets.AddRange(player1.Sets.Where(x => 
            (x.Player1.Id == player1.Id && x.Player2.Id == player2.Id) 
            || (x.Player1.Id == player2.Id && x.Player2.Id == player1.Id)));
            /// <summary>
            /// Assign number of set wins for Player 1 and Player 2 using established shared sets
            /// </summary>
            this.Player1SetWins = this.Sets.Where(x => x.Winner.Id == player1.Id && x.Loser.Id == player2.Id).Count();
            this.Player2SetWins = this.Sets.Where(x => x.Winner.Id == player2.Id && x.Loser.Id == player1.Id).Count();
            /// <summary>
            /// Assign number of game wins for Player 1 and Player 2 using established shared games
            /// </summary>
            foreach (Set set in this.Sets)
            {
                this.Player1GameWins += set.Games.Where(x => x.Winner == player1.Id && x.Loser == player2.Id).Count();
                this.Player2GameWins += set.Games.Where(x => x.Winner == player2.Id && x.Loser == player1.Id).Count();
            }
        }

    }
}
