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
        public Character Character { get; set; }
        public WinLossRecord WinLossRecord { get; set; }
        // Total games played with character by player divivded by total games played by player = CharacterUsage
        public decimal CharacterUsage { get; set; }

        public CharacterPlayerStats()
        {

        }

        public CharacterPlayerStats(Character character)
        {
            this.Character = character;
        }
    }
}
