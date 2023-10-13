using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IUserOfficeRoleRepository
    {
        Task<IReadOnlyList<UserOfficeRole>> FindAllAsync();
        Task<UserOfficeRole?> FindByIdAsync(int userId, int officeId, int roleId);
        Task<UserOfficeRole> SaveAsync(UserOfficeRole userOfficeRole);
        Task<UserOfficeRole> EditAsync(UserOfficeRole userOfficeRole);
        Task<UserOfficeRole> DisabledAsync(UserOfficeRole userOfficeRole);


    }
}
