using FightCore.Models.Characters;
using Microsoft.EntityFrameworkCore;

namespace FightCore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ComboConfiguration : IEntityTypeConfiguration<Combo>
    {
        public void Configure(EntityTypeBuilder<Combo> builder)
        {
            builder.HasMany(x => x.DamageMetrics).WithOne();
            builder.HasMany(x => x.Performers).WithOne(x => x.Combo).HasForeignKey(x => x.ComboId);
            builder.HasMany(x => x.Receivers).WithOne(x => x.Combo).HasForeignKey(x => x.ComboId);
            builder.HasOne(x => x.Author).WithMany();
        }
    }
}
