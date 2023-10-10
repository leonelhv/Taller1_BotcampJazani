using Jazani.Core.Paginations;
using Jazani.Domain.Cores.Paginations;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistenses;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infraestructure.Mc.Persistences;
public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPaginator<Investment> _paginator;

    public InvestmentRepository(ApplicationDbContext dbContext, IPaginator<Investment> paginator) : base(dbContext)
    {
        _dbContext = dbContext;
        _paginator = paginator;
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

    public async Task<ResponsePagination<Investment>> PaginatedSearch(RequestPagination<Investment> request)
    {
        var filter = request.Filter;

        var query = _dbContext.Set<Investment>().AsQueryable();

        if (filter is not null)
        {
            query = query
                .Where(x =>
                    (filter.MiningConcessionId == 0 || x.MiningConcessionId == filter.MiningConcessionId)
                    && (filter.CurrencyTypeId == 0 || x.CurrencyTypeId == filter.CurrencyTypeId)
                    && (filter.State == false || x.State == filter.State)
                );
        }

        query = query.OrderByDescending(x => x.Id)
           .Include(t => t.Investmentconcept)
           .Include(t => t.Holder)
           .Include(t => t.Investmenttype)
           .Include(t => t.MiningConcession)
           .Include(t => t.MeasureUnit)
           .Include(t => t.PeriodType)
           ;

        return await _paginator.Paginate(query, request);
    }
}
