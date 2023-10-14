using Jazani.Domain.Ge.Models;
using Jazani.Domain.Ge.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistenses;

namespace Jazani.Infrastructure.Ge.Persistences
{
    public class PersonTypeRepository : CrudRepository<PersonType, int>, IPersonTypeRepository
    {
        public PersonTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

