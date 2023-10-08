using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistenses;
using Jazani.Taller.Domain.Mc.Models;
using Jazani.Taller.Domain.Mc.Repositories;

namespace Jazani.Taller.Infrastructure.Mc.Persistences
{
    public class MiningConcessionRepository : CrudRepository<MiningConcession, int>, IMiningConcessionRepository
    {
        public MiningConcessionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
