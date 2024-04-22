using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(e => e.id);
            builder.ToTable("service");
            builder.Property(e => e.id).HasColumnName("idservices");
            builder.Property(e => e.NameService).HasColumnName("nameservice");
            
        }
    }
}
