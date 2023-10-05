using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IUserOfficeRoleRepository
    {
        Task<IReadOnlyList<UserOfficeRole>> FindAllAsync();
        Task<UserOfficeRole?> FindByIdAsync(int UserId, int OfficeId, int RoleId);
        Task<UserOfficeRole> SaveAsync(UserOfficeRole userOfficeRole);
    }
}
