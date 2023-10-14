using Jazani.Domain.Admins.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Configurations
{
    public class UserjwtConfiguration : IEntityTypeConfiguration<Userjwt>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Userjwt> builder)
        {
            builder.ToTable("users", "adm");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.LastName).HasColumnName("lastname");
            builder.Property(t => t.Email).HasColumnName("email");
            builder.Property(t => t.Password).HasColumnName("password");
            builder.Property(t => t.RoleId).HasColumnName("roleid");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}

