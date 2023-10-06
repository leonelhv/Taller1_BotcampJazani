using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IUserOfficeRoleRepository
    {
        Task<IReadOnlyList<UserOfficeRole>> FindAllAsync();
        Task<UserOfficeRole?> FindByIdAsync(int UserId, int OfficeId, int RoleId);
        Task<UserOfficeRole> UpdateAsync(UserOfficeRole userOfficeRole, int UserId, int OfficeId, int RoleId);
        Task<UserOfficeRole> DeleteAsync(UserOfficeRole userOfficeRole);
        Task<UserOfficeRole> AddAsync(UserOfficeRole userOfficeRole);
    }
}
