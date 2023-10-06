using Jazani.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Jazani.Infrastructure.Cores.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<User>()
                .HasMany(e => e.OfficeRoles)
                .WithMany(e => e.Users)
                .UsingEntity<UserOfficeRole>();

        }

    }
}



