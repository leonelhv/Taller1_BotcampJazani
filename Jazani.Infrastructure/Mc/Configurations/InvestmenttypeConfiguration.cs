using Jazani.Infrastructure.Cores.Converters;
using Jazani.Taller.Domain.Mc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Taller.Infrastructure.Mc.Configuration
{
    public class InvestmenttypeConfiguration : IEntityTypeConfiguration<Investmenttype>
    {
        public void Configure(EntityTypeBuilder<Investmenttype> builder)
        {
            builder.ToTable("investmenttype", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationDate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
        }

    }
}
