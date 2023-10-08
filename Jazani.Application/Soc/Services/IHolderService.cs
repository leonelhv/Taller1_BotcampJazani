using Jazani.Application.Soc.Dtos.Holders;

namespace Jazani.Application.Soc.Services
{
    public interface IHolderService
    {
        Task<IReadOnlyList<HolderDto>> FindAllAsync();
        Task<HolderDto> FindByIdAsync(int id);
    }
}
