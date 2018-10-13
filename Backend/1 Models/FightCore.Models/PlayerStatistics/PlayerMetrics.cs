using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models;
using FightCore.Models.Characters;
using FightCore.Models.Shared;

namespace FightCore.Models.PlayerStatistics
{
    public class PlayerMetrics
    {
        public Player Player { get; set; }
        /// <summary>
        /// Private list of characters since only needed for calculation, potentially can become a "get characters" method somewhere else to avoid recode
        /// I am also probably supposed to put such a method in a PlayerService of sorts, but I am not entirely familiar with the architecture
        /// Bare with me ;-;
        /// </summary>
        private List<Character> Characters { get; set; }
        public List<CharacterPlayerStats> CharacterPlayerStats { get; set; }

        public PlayerMetrics (Player player)
        {
            this.Player = player;
            this.Characters = new List<Character>(); //Change to probably a service method for returning a result set of characters used by a given player
            this.CharacterPlayerStats = new List<CharacterPlayerStats>();
            foreach (Character character in this.Characters)
            {
                this.CharacterPlayerStats.Add(new CharacterPlayerStats(player, character));
            }
        }

    }
}
