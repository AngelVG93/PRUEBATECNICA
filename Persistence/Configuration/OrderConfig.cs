using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.id);
            builder.ToTable("orders");
            builder.Property(e => e.id).HasColumnName("idorders");

            builder.Property(e => e.Description).HasColumnName("descriptions");
        }
    }
}
