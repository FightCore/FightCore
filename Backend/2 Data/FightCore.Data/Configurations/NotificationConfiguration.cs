using FightCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FightCore.Data.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // One to many relationship with users
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);

            // Strings by default can be nullable but all notifications need these properties
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.RouteLink).IsRequired();
        }
    }
}