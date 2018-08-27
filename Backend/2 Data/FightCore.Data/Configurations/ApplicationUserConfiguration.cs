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
            const string password = "Welcome1!";
            var email = "user@test.nl";
            var user = new ApplicationUser()
            {
                Id = 1,
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEEF7WgDaqY347VdczNcxXwYb6F7IkpBvK5zRg/PU/t5hYIAgKGZanV5GJEco41ILUQ==",
                SecurityStamp = "WYJC6FNA3WBJEXMXPVVNJTJOB3ZQLL2D",
                ConcurrencyStamp = "680f3083-462f-4c8f-ba9a-c09a44145495"
            };

            builder.HasData(user);
        }
    }
}
