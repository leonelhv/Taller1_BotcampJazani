using Jazani.Application.Admins.Dtos.UserOfficeRoles;

namespace Jazani.Application.Admins.Services
{
    public interface IUserOfficeRoleService
    {
        Task<IReadOnlyList<UserOfficeRoleDto>> FindAllAsync();
        Task<UserOfficeRoleDto?> FindByIdAsync(int userId, int officeId, int roleId);
        Task<UserOfficeRoleDto> CreateAsync(UserOfficeRoleSaveDto userOfficeRoleSaveDto);
        Task<UserOfficeRoleDto> EditAsync(int userId, int officeId, int roleId);
        Task<UserOfficeRoleDto> DisabledAsync(int userId, int officeId, int roleId);
    }
}
