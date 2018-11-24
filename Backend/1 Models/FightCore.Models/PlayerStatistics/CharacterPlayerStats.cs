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
        public WinLossRecord WinLossRecord { get; set; }
        public decimal CharacterUsage { get; set; }

        public CharacterPlayerStats()
        {

        }

        public CharacterPlayerStats(Player player, Character character)
        {
            this.Player = player;
            this.Character = character;
        }
    }
}
