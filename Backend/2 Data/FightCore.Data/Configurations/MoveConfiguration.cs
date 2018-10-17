using FightCore.Models.Characters;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MoveConfiguration : IEntityTypeConfiguration<Move>
    {
        public void Configure(EntityTypeBuilder<Move> builder)
        {
            builder.HasOne(x => x.Input).WithMany();
        }
    }
}
