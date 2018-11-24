using System.Collections.Generic;

namespace FightCore.Models.PlayerStatistics
{
    public class HeadToHead
    {
        public HeadToHeadPlayer Player1 { get; set; }
        public HeadToHeadPlayer Player2 { get; set; }
        public List<Set> Sets { get; set; }

        public HeadToHead ()
        {

        }

        public HeadToHead (HeadToHeadPlayer player1, HeadToHeadPlayer player2, List<Set> sets)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            this.Sets = sets;
        }
    }
}
