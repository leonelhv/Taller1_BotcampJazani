using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistenses;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class UserOfficeRoleRepository : CrudRepository<UserOfficeRole, int>, IUserOfficeRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserOfficeRoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<UserOfficeRole>> FindAllAsync()
        {
            return await _dbContext.Set<UserOfficeRole>()
                .Include(t => t.User)
                .Include(t => t.Role)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<UserOfficeRole?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<UserOfficeRole>()
                .Include(t => t.User)
                .Include(t => t.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.UserId == id);
        }

    }
}
