using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class UserOfficeRoleRepository : IUserOfficeRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserOfficeRoleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<UserOfficeRole>> FindAllAsync()
        {
            return await _dbContext.Set<UserOfficeRole>()
                .Include(t => t.User)
                .Include(t => t.Office)
                .Include(t => t.Role)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UserOfficeRole?> FindByIdAsync(int userId, int officeId, int roleId)
        {

            return await _dbContext.Set<UserOfficeRole>().FindAsync(userId, officeId, roleId);


        }

        public async Task<UserOfficeRole> SaveAsync(UserOfficeRole userOfficeRole)
        {
            _dbContext.Set<UserOfficeRole>().Add(userOfficeRole);
            await _dbContext.SaveChangesAsync();
            return userOfficeRole;
        }

        public async Task<UserOfficeRole> EditAsync(UserOfficeRole userOfficeRole)
        {
            _dbContext.Set<UserOfficeRole>().Update(userOfficeRole);
            await _dbContext.SaveChangesAsync();
            return userOfficeRole;

        }

        public async Task<UserOfficeRole> DisabledAsync(UserOfficeRole userOfficeRole)
        {

            _dbContext.Set<UserOfficeRole>().Update(userOfficeRole);
            await _dbContext.SaveChangesAsync();
            return userOfficeRole;

        }

    }
}
