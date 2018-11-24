using System.Collections.Generic;
using FightCore.Models;
using FightCore.Models.Characters;
using FightCore.Models.Shared;

namespace FightCore.Models.PlayerStatistics
{
    public class PlayerMetric
    {
        public Player Player { get; set; }
        public List<Character> Characters { get; set; }
        public List<CharacterPlayerStats> CharacterPlayerStats { get; set; }

        public PlayerMetric()
        {

        }

        public PlayerMetric(Player player, List<Character> characters)
        {
            this.Player = player;
            this.Characters = characters;
        }

    }
}
