using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Cores.Persistenses
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<User>> FindAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> FindByIdAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> SaveAsync(User user)
        {
            EntityState state = _dbContext.Entry(user).State;

            _ = state switch
            {
                EntityState.Detached => _dbContext.Users.Add(user),
                EntityState.Modified => _dbContext.Users.Update(user),
            };

            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
