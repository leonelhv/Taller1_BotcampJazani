using Jazani.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Admins.Configurations
{
    public class UserOfficeRoleConfiguration
    {
        public class PeriocityConfiguration : IEntityTypeConfiguration<UserOfficeRole>
        {
            public void Configure(EntityTypeBuilder<UserOfficeRole> builder)
            {
                builder.ToTable("userofficerole", "adm");
                builder.HasKey(t => new { t.UserId, t.OfficeId, t.RoleId });
                builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate");
                builder.Property(t => t.State).HasColumnName("state");

                builder.HasOne(one => one.User).WithMany(many => many.UserOfficeRoles).HasForeignKey(fk => fk.UserId);
            }
        }
    }
}
