using Jazani.Domain.Admins.Models;
using Jazani.Domain.Cores.Repositories;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IUserjwtRepository : ICrudRepository<Userjwt, int>
    {
        Task<Userjwt?> FindByEmailAsync(string email);
    }
}
