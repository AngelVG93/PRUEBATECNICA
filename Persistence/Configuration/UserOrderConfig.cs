using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class UserOrderConfig : IEntityTypeConfiguration<UserOrder>
    {
        public void Configure(EntityTypeBuilder<UserOrder> builder)
        {
            builder.HasKey(e => e.id);
            builder.ToTable("users_orders");
            builder.Property(e => e.id).HasColumnName("idusersorders");

            builder.Property(e => e.IdUser).HasColumnName("idusers");
            builder.Property(e => e.IdOrder).HasColumnName("idorders");
            builder.Property(e => e.DateOrder).HasColumnName("dateOrder");

            builder.HasOne(e => e.IdUserNavigation)
            .WithMany(e => e.UserOrder)
            .HasForeignKey(e => e.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__users_ord__iduse__4A8310C6");

            builder.HasOne(e => e.IdOrderNavigation)
              .WithMany(e => e.UserOrder)
              .HasForeignKey(e => e.IdOrder)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__users_ord__idord__4B7734FF");
        }
    }
}
