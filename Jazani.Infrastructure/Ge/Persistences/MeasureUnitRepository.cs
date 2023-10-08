using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistenses;
using Jazani.Taller.Domain.Ge.Models;
using Jazani.Taller.Domain.Ge.Repositories;

namespace Jazani.Taller.Infrastructure.Ge.Persistences
{
    public class MeasureUnitRepository : CrudRepository<MeasureUnit, int>, IMeasureUnitRepository
    {
        public MeasureUnitRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}
