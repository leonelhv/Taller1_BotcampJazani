using Jazani.Domain.Admins.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Admins.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user", "adm");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.RoleId).HasColumnName("roleid");
            builder.Property(t => t.Username).HasColumnName("username");
            builder.Property(t => t.Password).HasColumnName("password");
            builder.Property(t => t.UserId).HasColumnName("userid");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
            builder.Property(t => t.LdapAuthentication).HasColumnName("ldapauthentication");
            builder.Property(t => t.TokenUuid).HasColumnName("tokenuuid");
            builder.Property(t => t.NotificationCount).HasColumnName("notificationcount");
            builder.Property(t => t.IsInspector).HasColumnName("isinspector");




        }
    }
}

