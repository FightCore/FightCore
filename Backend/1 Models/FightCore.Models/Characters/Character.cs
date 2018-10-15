using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Shared;

namespace FightCore.Models.Characters
{
    public class Character : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Media> Media { get; set; }
        public List<CharacterTechnique> Techniques { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public List<Move> Moves { get; set; }
        public List<Combo> Combos { get; set; }
    }
}
