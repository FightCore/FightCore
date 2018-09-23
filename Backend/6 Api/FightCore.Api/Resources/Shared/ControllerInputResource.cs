using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Resources.Shared
{
    public class ControllerInputResource
    {
        public int Id { get; set; }
        public string TextDescription { get; set; }
        public string KeyCode { get; set; }
    }
}
