using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace FightCore.Models
{
    public class ApplicationUser : IdentityUser<int>, IEntity
    {
    }
}
