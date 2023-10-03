using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IPeriocityRepository
    {
        Task<IReadOnlyList<Periocity>> FindAllAsync();
        Task<Periocity?> FindByIdAsync(int id);
        Task<Periocity> SaveAsync(Periocity office);
    }
}
