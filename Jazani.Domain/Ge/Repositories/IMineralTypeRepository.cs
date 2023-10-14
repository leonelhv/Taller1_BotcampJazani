using Jazani.Domain.Cores.Repositories;
using Jazani.Domain.Ge.Models;

namespace Jazani.Domain.Ge.Repositories
{
    public interface IMineralTypeRepository : ICrudRepository<MineralType, int>, IPaginatedRepository<MineralType>
    {

    }
}

