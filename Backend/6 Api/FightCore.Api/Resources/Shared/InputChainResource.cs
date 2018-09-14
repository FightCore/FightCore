using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FightCore.Api.Resources.Characters;

namespace FightCore.Api.Resources.Shared
{
    public class InputChainResource
    {
        public int Id { get; set; }
        public MoveResource Move { get; set; }
        public TechniqueResource Technique { get; set; }
        public ControllerInputResource Input { get; set; }
        public int FirstFrame { get; set; }
        public int LastFrame { get; set; }
    }
}
