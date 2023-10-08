using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistenses;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructure.Mc.Persistences;
public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public InvestmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<IReadOnlyList<Investment>> FindAllAsync()
    {
        return await _dbContext.Set<Investment>()
              .Include(i => i.Investmentconcept).Include(i => i.Investmenttype)
              .Include(i => i.MeasureUnit).Include(i => i.PeriodType)
              .AsNoTracking()
              .ToListAsync();
    }

    public override async Task<Investment?> FindByIdAsync(int id)
    {
        return await _dbContext.Set<Investment>()
               .Include(i => i.Investmentconcept).Include(i => i.Investmenttype)
              .Include(i => i.MeasureUnit).Include(i => i.PeriodType)
              .FirstOrDefaultAsync(t => t.Id == id);
    }


}
