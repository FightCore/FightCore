using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FightCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FightCore.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var email = "user@test.nl";
            var user = new ApplicationUser
            {
                Id = 1,
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
				//The hashed password is Welcome1!
				PasswordHash = "$2y$12$AqxWrJO46eF27pK/i/YgR.3NWF5J4Ii058fFr.kQKDToFZjjxAcPe",
                SecurityStamp = "WYJC6FNA3WBJEXMXPVVNJTJOB3ZQLL2D",
                ConcurrencyStamp = "680f3083-462f-4c8f-ba9a-c09a44145495"
            };

            var email2 = "test2@test.com";
            var user2 = new ApplicationUser
            {
                Id = 2,
                UserName = "test2",
                NormalizedUserName = "TEST2",
                Email = email2,
                NormalizedEmail = email2.ToUpper(),
                EmailConfirmed = true,
				//The hashed password is Welcome1!
				PasswordHash = "$2y$12$AqxWrJO46eF27pK/i/YgR.3NWF5J4Ii058fFr.kQKDToFZjjxAcPe",
                SecurityStamp = "WYJC6FNA3WBJEXMXPVVNJTJOB3ZQLL2D",
                ConcurrencyStamp = "680f3083-462f-4c8f-ba9a-c09a44145495"
            };

            builder.HasData(user, user2);
        }
    }
}
