using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class PermissRolesServicesConfig : IEntityTypeConfiguration<PermissRolesServices>
    {
        public void Configure(EntityTypeBuilder<PermissRolesServices> builder)
        {
            builder.HasKey(e => e.id);
            builder.ToTable("permiss_roles_services");
            builder.Property(e => e.id).HasColumnName("idpermisroleservice");
            builder.Property(e => e.IdPermissions).HasColumnName("idpermissions");
            builder.Property(e => e.IdRolesService).HasColumnName("idrolesservice");

            builder.HasOne(e => e.IdPermissionsNavigation)
             .WithMany(e => e.PermissRolesServices)
             .HasForeignKey(e => e.IdPermissions)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK__permiss_r__idper__3F115E1A");

            builder.HasOne(e => e.IdRolesServicesNavigation)
             .WithMany(e => e.PermissRolesServices)
             .HasForeignKey(e => e.IdRolesService)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK__permiss_r__idrol__40058253");
        }
    }
}
