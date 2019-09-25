using FightCore.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FightCore.Data.Configurations
{
    public class UserCharacterConfiguration : IEntityTypeConfiguration<UserCharacter>
    {
        public void Configure(EntityTypeBuilder<UserCharacter> builder)
        {
            builder.HasKey(x => new { x.CharacterId, x.UserId });

            builder.HasOne(x => x.Character).WithMany().HasForeignKey(x => x.CharacterId);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
