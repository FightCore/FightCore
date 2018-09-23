using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Api.Resources.Shared;
using FightCore.Models.Shared;

namespace FightCore.Api.Resources.Characters
{
    public class ComboResource
    {
        public int Id { get; set; }
        public List<CharacterResource> WorksOn { get; set; }
        public List<InputChainResource> Inputs { get; set; }
        public double MinimumDamage { get; set; }
        public double MaximumDamage { get; set; }
    }
}
