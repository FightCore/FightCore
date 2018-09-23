using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.PlayerStatistics;
using FightCore.Models.Shared;

namespace FightCore.Models.Characters
{
    public class Character : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Media> Media { get; set; }
        public List<Technique> Techniques { get; set; }
        public Game Game { get; set; }
        public List<Move> Moves { get; set; }
        public List<Combo> Combos { get; set; }
        /// <summary>
        /// The games from a set where the character is used
        /// </summary>
        /// <value>A list of SetGame objects where this character is used</value>
        public List<SetGame> Games { get; set; }
    }
}
