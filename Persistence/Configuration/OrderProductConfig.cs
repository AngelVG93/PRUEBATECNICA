using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class OrderProductConfig : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(e => e.id);
            builder.ToTable("orders_products");
            builder.Property(e => e.id).HasColumnName("idordersproduct");

            builder.Property(e => e.DateOrder).HasColumnName("dateorder");
            builder.Property(e => e.IdOrder).HasColumnName("idorders");
            builder.Property(e => e.IdProduct).HasColumnName("idproduct");

           builder.HasOne(e => e.IdOrderNavigation)
          .WithMany(e => e.OrderProduct)
          .HasForeignKey(e => e.IdOrder)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK__orders_pr__idord__503BEA1C");

            builder.HasOne(e => e.IdProductNavigation)
            .WithMany(e => e.OrderProduct)
            .HasForeignKey(e => e.IdProduct)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__orders_pr__idpro__51300E55");
        }
    }
}
