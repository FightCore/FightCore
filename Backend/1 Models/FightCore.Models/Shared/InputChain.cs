using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Characters;

namespace FightCore.Models.Shared
{
    public class InputChain : IEntity
    {
        public int Id { get; set; }
        public Move Move { get; set; }
        public Technique Technique { get; set; }
        public ControllerInput Input { get; set; }
        public int FirstFrame { get; set; }
        public int LastFrame { get; set; }
    }
}
