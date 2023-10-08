using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistenses;
using Jazani.Taller.Domain.Mc.Models;
using Jazani.Taller.Domain.Mc.Repositories;

namespace Jazani.Taller.Infrastructure.Mc.Persistences
{
    public class InvestmenttypeRepository : CrudRepository<Investmenttype, int>, IInvestmenttypeRepository
    {
        public InvestmenttypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
