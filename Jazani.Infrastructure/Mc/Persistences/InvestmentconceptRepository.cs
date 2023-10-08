using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistenses;

namespace Jazani.Infraestructure.Mc.Persistences;
public class InvestmentconceptRepository : CrudRepository<Investmentconcept, int>, IInvestmentconceptRepository
{
    public InvestmentconceptRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
