using Jazani.Application.Admins.Dtos.Roles;

namespace Jazani.Application.Admins.Services
{
    public interface IRoleService
    {
        Task<IReadOnlyList<RoleDto>> FindAllAsync();
        Task<RoleDto?> FindByIdAsync(int id);
        Task<RoleDto> CreateAsync(RoleSaveDto roleSaveDto);
        Task<RoleDto> EditAsync(int id, RoleSaveDto roleSaveDto);
        Task<RoleDto> DisabledAsync(int id);
    }
}
