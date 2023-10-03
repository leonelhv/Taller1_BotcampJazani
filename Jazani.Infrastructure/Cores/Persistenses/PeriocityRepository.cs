using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Cores.Persistenses
{
    public class PeriocityRepository : IPeriocityRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PeriocityRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<Periocity>> FindAllAsync()
        {
            return await _dbContext.Periocities.ToListAsync();
        }

        public async Task<Periocity?> FindByIdAsync(int id)
        {
            return await _dbContext.Periocities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Periocity> SaveAsync(Periocity periocity)
        {
            EntityState state = _dbContext.Entry(periocity).State;

            _ = state switch
            {
                EntityState.Detached => _dbContext.Periocities.Add(periocity),
                EntityState.Modified => _dbContext.Periocities.Update(periocity),
            };

            await _dbContext.SaveChangesAsync();
            return periocity;
        }
    }
}
