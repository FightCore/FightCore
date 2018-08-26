using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Shared;

namespace FightCore.Models.Characters
{
    public class Technique
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ControllerInput> ControllerInputs { get; set; }
        public Game Game { get; set; }
        public List<Media> Media { get; set; }
    }
}
