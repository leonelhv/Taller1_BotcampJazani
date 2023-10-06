using Jazani.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Jazani.Infrastructure.Admins.Configurations
{

    public class OfficeRoleConfiguration : IEntityTypeConfiguration<OfficeRole>
    {
        public void Configure(EntityTypeBuilder<OfficeRole> builder)
        {
            builder.ToTable("officerole", "adm");
            builder.HasKey(t => new { t.OfficeId, t.RoleId });
            builder.Property(t => t.RoleId).HasColumnName("roleid");
            builder.Property(t => t.OfficeId).HasColumnName("officeid");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate");
            builder.Property(t => t.State).HasColumnName("state");



        }
    }

}
