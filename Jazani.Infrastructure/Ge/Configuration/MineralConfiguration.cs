using Jazani.Domain.Ge.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Ge.Configuration
{
    public class MineralConfiguration : IEntityTypeConfiguration<Mineral>
    {
        public void Configure(EntityTypeBuilder<Mineral> builder)
        {
            builder.ToTable("mineral", "ge");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.Symbol).HasColumnName("symbol");
            builder.Property(t => t.MineraltypeId).HasColumnName("mineraltypeid");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");


            builder.HasOne(one => one.MineralType).WithMany(many => many.Minerals)
                .HasForeignKey(fk => fk.MineraltypeId);
        }
    }
}

