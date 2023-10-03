using Jazani.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Admins.Configurations
{
    public class PeriocityConfiguration : IEntityTypeConfiguration<Periocity>
    {
        public void Configure(EntityTypeBuilder<Periocity> builder)
        {
            builder.ToTable("periocity", "adm");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate");
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
