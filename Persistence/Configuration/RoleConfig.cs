using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.id);
            builder.ToTable("roles");
            builder.Property(e => e.id).HasColumnName("idroles");

            builder.Property(e => e.Name).HasColumnName("nameroles");
        }
    }
}
