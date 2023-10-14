using Jazani.Application.Admins.Dtos.Users;

namespace Jazani.Application.Admins.Services
{
    public interface IUserService
    {
        Task<IReadOnlyList<UsersDto>> FindAllAsync();
        Task<UsersDto?> FindByIdAsync(int id);
        Task<UsersDto> CreateAsync(UsersSaveDto userSaveDto);
        Task<UsersDto> EditAsync(int id, UsersSaveDto userSaveDto);
        Task<UsersDto> DisabledAsync(int id);
    }
}
