using Microsoft.AspNetCore.Identity;

namespace FightCore.Models
{
    public class ApplicationUser : IdentityUser<int>, IEntity
    {
    }
}
