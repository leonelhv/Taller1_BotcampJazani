using Jazani.Application.Admins.Dtos.UserOfficeRoles;

namespace Jazani.Application.Admins.Services
{
    public interface IUserOfficeRoleService
    {
        Task<IReadOnlyList<UserOfficeRoleDto>> FindAllAsync();
        Task<UserOfficeRoleDto?> FindByIdAsync(int id);
        Task<UserOfficeRoleDto> CreateAsync(UserOfficeRoleSaveDto userOfficeRoleSaveDto);
        Task<UserOfficeRoleDto> EditAsync(int id, UserOfficeRoleSaveDto userOfficeRoleSaveDto);
        Task<UserOfficeRoleDto> DisabledAsync(int id);
    }
}
