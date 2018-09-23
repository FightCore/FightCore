using System;
using System.Collections.Generic;
using System.Text;

namespace FightCore.Models.Shared
{
    public class ControllerInput : IEntity
    {
        public int Id { get; set; }
        public string TextDescription { get; set; }
        public string KeyCode { get; set; }
    }
}
