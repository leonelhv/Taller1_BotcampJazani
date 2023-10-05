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

        public async Task<UserOfficeRole> SaveAsync(UserOfficeRole userOfficeRole)
        {
            EntityState state = _dbContext.Entry(userOfficeRole).State;

            _ = state switch
            {
                EntityState.Detached => _dbContext.Set<UserOfficeRole>().Add(userOfficeRole),
                EntityState.Modified => _dbContext.Set<UserOfficeRole>().Update(userOfficeRole),
            };

            _dbContext.Entry(userOfficeRole).Reference(e => e.User).Load();
            _dbContext.Entry(userOfficeRole).Reference(e => e.Role).Load();

            await _dbContext.SaveChangesAsync();
            return userOfficeRole;
        }
    }
}
