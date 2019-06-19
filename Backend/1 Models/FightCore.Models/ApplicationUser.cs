using System;

using Microsoft.AspNetCore.Identity;

namespace FightCore.Models
{
    public class ApplicationUser : IdentityUser<int>, IEntity
    {
        /// <summary>
        /// Gets or sets the user's flair url.
        /// </summary>
        public string FlairUrl { get; set; }
    }
}
