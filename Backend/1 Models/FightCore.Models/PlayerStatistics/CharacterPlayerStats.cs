using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FightCore.Models;
using FightCore.Models.Characters;
using FightCore.Models.Shared;

namespace FightCore.Models.PlayerStatistics
{
    public class CharacterPlayerStats
    {
        public Player Player { get; set; }
        public Character Character { get; set; }
        /// <summary>
        /// Private list of games since only needed for calculation, potentially can become a "get setgames" method somewhere else to avoid recode
        /// I am also probably supposed to put such a method in a PlayerService of sorts, but I am not entirely familiar with the architecture
        /// Bare with me ;-;
        /// </summary>
        private List<SetGame> Games { get; set; }
        public decimal WinPercentage { get; set; }
        public decimal CharacterUsage { get; set; }

        ///Probably need to move calculations to the service/controller layer?
        public CharacterPlayerStats(Player player, Character character)
        {
            this.Player = player;
            this.Character = character;
            this.Games = new List<SetGame>(); //Change the below probably to a service method for returning a result set of set games played by a given player
            foreach (Set set in player.Sets)
            {
                this.Games.AddRange(set.Games);
            }
            /// <summary>
            /// Total games won with character by player divivded by total games played with character by player = win percentage
            /// </summary>
            this.WinPercentage = 
                (decimal)this.Games.Where(x => 
                x.Winner == player.Id && 
                ((x.Character1 == character && x.Set.Player1Id == player.Id) 
                || (x.Character2 == character && x.Set.Player2Id == player.Id))).Count() 
                / (decimal)this.Games.Where(x =>
                (x.Character1 == character && x.Set.Player1Id == player.Id) 
                || (x.Character2 == character && x.Set.Player2Id == player.Id)).Count();
            /// <summary>
            /// Total games played with character by player divivded by total games played by player = character usage
            /// </summary>
            this.CharacterUsage =
                (decimal)this.Games.Where(x =>
                (x.Character1 == character && x.Set.Player1Id == player.Id) 
                || (x.Character2 == character && x.Set.Player2Id == player.Id)).Count()
                / (decimal)this.Games.Count();
        }
    }
}
