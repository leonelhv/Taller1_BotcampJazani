using Jazani.Application.Admins.Dtos.Users;

namespace Jazani.Application.Admins.Services
{
    public interface IUserService
    {
        Task<IReadOnlyList<UserDto>> FindAllAsync();
        Task<UserDto?> FindByIdAsync(int id);
        Task<UserDto> CreateAsync(UserSaveDto userSaveDto);
        Task<UserDto> EditAsync(int id, UserSaveDto userSaveDto);
        Task<UserDto> DisabledAsync(int id);
    }
}
