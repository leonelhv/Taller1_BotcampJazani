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
                .Include(t => t.Role)
                .AsNoTracking().ToListAsync();
        }

        public async Task<UserOfficeRole?> FindByIdAsync(int UserId, int OfficeId, int RoleId)
        {
            return await _dbContext.Set<UserOfficeRole>()
                 .Include(t => t.User)
                 .Include(t => t.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == UserId && x.OfficeId == OfficeId && x.RoleId == RoleId);
        }

        public async Task<UserOfficeRole> UpdateAsync(UserOfficeRole userOfficeRole, int UserId, int OfficeId, int RoleId)
        {

            var existingUserOfficeRole = await _dbContext.Set<UserOfficeRole>()
             .FirstOrDefaultAsync(uor =>
          uor.UserId == UserId &&
          uor.OfficeId == OfficeId &&
          uor.RoleId == RoleId);


            _dbContext.Set<UserOfficeRole>().Remove(existingUserOfficeRole);
            await _dbContext.SaveChangesAsync();
            _dbContext.Set<UserOfficeRole>().Add(userOfficeRole);
            await _dbContext.SaveChangesAsync();
            return userOfficeRole;

        }

        public async Task<UserOfficeRole> AddAsync(UserOfficeRole userOfficeRole)
        {
            _dbContext.Set<UserOfficeRole>().Add(userOfficeRole);
            await _dbContext.SaveChangesAsync();
            return userOfficeRole;
        }

        public async Task<UserOfficeRole> DeleteAsync(UserOfficeRole userOfficeRole)
        {
            _dbContext.Set<UserOfficeRole>().Update(userOfficeRole);
            await _dbContext.SaveChangesAsync();
            return userOfficeRole;
        }
    }
}
