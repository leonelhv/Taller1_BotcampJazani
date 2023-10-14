using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistenses;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class UserjwtRepository : CrudRepository<Userjwt, int>, IUserjwtRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserjwtRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Userjwt?> FindByEmailAsync(string email)
        {
            return await _dbContext.Set<Userjwt>()
                .Where(t => t.Email.ToUpper().Equals(email.ToUpper()))
                .FirstOrDefaultAsync();
        }
    }
}
