using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class RolesServicesConfig : IEntityTypeConfiguration<RolesServices>
    {
        public void Configure(EntityTypeBuilder<RolesServices> builder)
        {
            builder.HasKey(e => e.id);
            builder.ToTable("roles_services");
            builder.Property(e => e.id).HasColumnName("idrolesservices");
            builder.Property(e => e.IdServices).HasColumnName("idservices");
            builder.Property(e => e.IdRoles).HasColumnName("idroles");

            builder.HasOne(e => e.IdServiceNavigation)
              .WithMany(e => e.RolesServices)
              .HasForeignKey(e => e.IdServices)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__roles_ser__idrol__3C34F16F");

            builder.HasOne(e => e.IdRoleNavigation)
              .WithMany(e => e.RolesServices)
              .HasForeignKey(e => e.IdRoles)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK__roles_ser__idser__3B40CD36");
        }
    }
}
