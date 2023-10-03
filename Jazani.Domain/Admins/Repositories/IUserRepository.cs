using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IUserRepository
    {
        Task<IReadOnlyList<User>> FindAllAsync();
        Task<User?> FindByIdAsync(int id);
        Task<User> SaveAsync(User user);
    }
}
