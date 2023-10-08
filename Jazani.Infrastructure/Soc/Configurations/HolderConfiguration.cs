using Jazani.Domain.Soc.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Soc.Configurations
{
    public class HolderConfiguration : IEntityTypeConfiguration<Holder>
    {
        public void Configure(EntityTypeBuilder<Holder> builder)
        {
            builder.ToTable("holder", "soc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id");
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Lastname).HasColumnName("lastname");
            builder.Property(t => t.MaidenName).HasColumnName("maidenname");
            builder.Property(t => t.Documentnumber).HasColumnName("documentnumber");
            builder.Property(t => t.Landline).HasColumnName("landline");
            builder.Property(t => t.Mobile).HasColumnName("mobile");
            builder.Property(t => t.Corporatemail).HasColumnName("corporatemail");
            builder.Property(t => t.Personalmail).HasColumnName("personalmail");
            builder.Property(t => t.State).HasColumnName("state");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
        }
    }
}
