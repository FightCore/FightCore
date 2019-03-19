using System;
using System.Collections.Generic;
using System.Text;

using FightCore.Models.Resources;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FightCore.Data.Configurations
{
    public class UpvotesConfiguration : IEntityTypeConfiguration<Upvote>
    {
        public void Configure(EntityTypeBuilder<Upvote> builder)
        {
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Post).WithMany().HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(x => new { x.PostId, x.UserId });
        }
    }
}
