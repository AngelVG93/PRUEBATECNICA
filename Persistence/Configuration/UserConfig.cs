using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.id);
            builder.ToTable("users");
            builder.Property(e => e.id).HasColumnName("idusers");

            builder.Property(e => e.Name).HasColumnName("nameuser");
            builder.Property(e => e.LastName).HasColumnName("lastname");
            builder.Property(e => e.IdentityNumber).HasColumnName("identitynumber");
            builder.Property(e => e.Password).HasColumnName("passworduser");
        }
    }
}
