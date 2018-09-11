using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FightCore.Api.Resources
{
    public class UserResource
    {
        public string Email { get; set; }

        public string UserName { get; set; }
    }

    public class UserResultResource : UserResource
    {
        public int Id { get; set; }

    }

    public class NewUserResource : UserResource
    {
        public string Password { get; set; }
    }
}
