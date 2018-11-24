using System;
using System.Collections.Generic;
using System.Text;

namespace FightCore.Models.PlayerStatistics
{
    public class HeadToHeadPlayer : Player
    {   /// <summary>
        /// Inherits from Player and adds below fields for use in HeadToHead objects
        /// </summary>
        public PlayerMetric PlayerMetric { get; set; }
        public int SetWins { get; set; }
        public int GameWins { get; set; }

        public HeadToHeadPlayer()
        {

        }

        public HeadToHeadPlayer(Player player, PlayerMetric metric)
        {
            this.Id = player.Id;
            this.Sponsor = player.Sponsor;
            this.SmashggId = player.SmashggId;
            this.Media = player.Media;
            this.Sets = player.Sets;
            this.PlayerMetric = metric;
        }

    }
}
