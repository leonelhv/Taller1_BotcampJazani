using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;

namespace Jazani.Infrastructure.Cores.Persistenses
{
    public class PeriocityRepository : CrudRepository<Periocity, int>, IPeriocityRepository
    {
        public PeriocityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
