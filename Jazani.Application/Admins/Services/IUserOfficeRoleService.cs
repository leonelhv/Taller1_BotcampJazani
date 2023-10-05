using Jazani.Application.Admins.Dtos.UserOfficeRoles;

namespace Jazani.Application.Admins.Services
{
    public interface IUserOfficeRoleService
    {
        Task<IReadOnlyList<UserOfficeRoleDto>> FindAllAsync();
        Task<UserOfficeRoleDto?> FindByIdAsync(int UserId, int OfficeId, int RoleId);
        Task<UserOfficeRoleBaseDto> CreateAsync(UserOfficeRoleSaveDto userOfficeRoleSaveDto);
        Task<UserOfficeRoleBaseDto> EditAsync(int UserId, int OfficeId, int RoleId, UserOfficeRoleSaveDto userOfficeRoleSaveDto);
        Task<UserOfficeRoleBaseDto> DisabledAsync(int UserId, int OfficeId, int RoleId);
    }
}
