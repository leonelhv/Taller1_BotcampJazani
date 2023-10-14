using Jazani.Domain.Ge.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Ge.Configuration
{
    public class MeasureUnitConfiguration : IEntityTypeConfiguration<MeasureUnit>
    {
        public void Configure(EntityTypeBuilder<MeasureUnit> builder)
        {
            builder.ToTable("measureunit", "ge");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id");
            builder.Property(t => t.MeasureUnitId).HasColumnName("measureunitid");
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Symbol).HasColumnName("symbol");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.FormulaConversion).HasColumnName("formulaconversion");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
        }

    }
}
