using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Shared;

namespace FightCore.Models.Characters
{
    public class Move : IMediaEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Character Character { get; set; }
        public ControllerInput Input { get; set; }
        public List<Media> Media { get; set; }
    }
}
