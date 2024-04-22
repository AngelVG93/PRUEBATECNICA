using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class PermissionsConfig : IEntityTypeConfiguration<Permissions>
    {
        public void Configure(EntityTypeBuilder<Permissions> builder)
        {
            builder.HasKey(e => e.id);
            builder.ToTable("permissions");
            builder.Property(e => e.id).HasColumnName("idpermissions");
            builder.Property(e => e.Name).HasColumnName("namepermission");
        }
    }
}
