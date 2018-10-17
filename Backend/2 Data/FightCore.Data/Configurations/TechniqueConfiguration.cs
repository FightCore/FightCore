using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FightCore.Data.Configurations
{
    public class TechniqueConfiguration : IEntityTypeConfiguration<Technique>
    {
        public void Configure(EntityTypeBuilder<Technique> builder)
        {
            builder.HasMany(x => x.Characters).WithOne(x => x.Technique).HasForeignKey(x => x.TechniqueId);
            builder.HasMany(x => x.Inputs).WithOne(x => x.Technique);
            builder.HasOne(x => x.Author).WithMany();
            builder.HasOne(x => x.Game).WithMany();
        }
    }
}
