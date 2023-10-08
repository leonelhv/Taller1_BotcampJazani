using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistenses;
using Jazani.Taller.Domain.Ge.Models;
using Jazani.Taller.Domain.Ge.Repositories;

namespace Jazani.Taller.Infrastructure.Ge.Persistences
{
    public class PeriodTypeRepository : CrudRepository<PeriodType, int>, IPeriodTypeRepository
    {
        public PeriodTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
