using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Shared;

namespace FightCore.Models.Characters
{
    public class Combo : IEntity
    {
        public int Id { get; set; }
        public List<Character> WorksOn { get; set; }
        public List<InputChain> Inputs { get; set; }
        public double MinimumDamage { get; set;}
        public double MaximumDamage { get; set; }
        public Character Character { get; set; }
    }
}
