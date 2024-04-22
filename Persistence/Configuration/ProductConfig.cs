using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.id);
            builder.ToTable("product");
            builder.Property(e => e.id).HasColumnName("idproduct");

            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Descriptionapp).HasColumnName("descriptionapp");
            builder.Property(e => e.Price).HasColumnName("price");
            builder.Property(e => e.numberunits).HasColumnName("numberunits");
        }
    }
}
