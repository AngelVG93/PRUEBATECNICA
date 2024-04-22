using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class LogExceptionConfig : IEntityTypeConfiguration<LogException>
    {
        public void Configure(EntityTypeBuilder<LogException> builder)
        {
            builder.HasKey(e => e.id);
            builder.ToTable("logexception");
            builder.Property(e => e.id).HasColumnName("idorderfoodapp");

            builder.Property(e => e.Name).HasColumnName("namelogexception");
            builder.Property(e => e.Message).HasColumnName("message");
            builder.Property(e => e.DateTimeException).HasColumnName("datetimeexception");
        }
    }
}
