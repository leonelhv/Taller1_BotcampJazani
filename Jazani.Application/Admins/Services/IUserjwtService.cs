using Jazani.Application.Admins.Dtos.Userjwts;
using Jazani.Application.Cores.Services;

namespace Jazani.Application.Admins.Services
{
    public interface IUserjwtService : ISaveService<UserjwtDto, UserjwtSaveDto, int>
    {
        Task<UserSecurityDto> LoginAsync(UserAuthDto userAuth);
    }
}
