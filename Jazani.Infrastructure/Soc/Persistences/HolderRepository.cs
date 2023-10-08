using Jazani.Domain.Soc.Models;
using Jazani.Domain.Soc.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistenses;

namespace Jazani.Infrastructure.Soc.Persistences
{
    public class HolderRepository : CrudRepository<Holder, int>, IHolderRepository
    {
        public HolderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
