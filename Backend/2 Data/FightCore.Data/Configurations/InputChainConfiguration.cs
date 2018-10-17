using System;
using System.Collections.Generic;
using System.Text;
using FightCore.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FightCore.Data.Configurations
{
    public class InputChainConfiguration : IEntityTypeConfiguration<InputChain>
    {
        public void Configure(EntityTypeBuilder<InputChain> builder)
        {
            builder.HasOne(x => x.Technique).WithMany();
            builder.HasOne(x => x.Input).WithMany();
            builder.HasOne(x => x.Move).WithMany();
        }
    }
}
