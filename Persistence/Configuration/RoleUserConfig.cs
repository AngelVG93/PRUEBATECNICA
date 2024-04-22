using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class RoleUserConfig : IEntityTypeConfiguration<RoleUser>
    {
        public void Configure(EntityTypeBuilder<RoleUser> builder)
        {
            builder.HasKey(e => e.id);
            builder.ToTable("roles_users");
            builder.Property(e => e.id).HasColumnName("idrolesusers");

            builder.Property(e => e.IdRole).HasColumnName("idroles");
            builder.Property(e => e.IdUser).HasColumnName("idusers");

            builder.HasOne(e => e.IdRoleNavigation)
              .WithMany(e => e.RoleUser)
              .HasForeignKey(e => e.IdRole)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__roles_use__iduse__45BE5BA9");

            builder.HasOne(e => e.IdUserNavigation)
           .WithMany(e => e.RoleUser)
           .HasForeignKey(e => e.IdUser)
           .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK__roles_use__idrol__44CA3770");
        }
    }
}
