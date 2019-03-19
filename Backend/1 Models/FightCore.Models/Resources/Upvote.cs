using System;
using System.Collections.Generic;
using System.Text;

namespace FightCore.Models.Resources
{
    public class Upvote
    {
        public int PostId { get; set; }

        public Post Post { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
