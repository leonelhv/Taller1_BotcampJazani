

using Jazani.Application.Admins.Dtos.Periocities;

namespace Jazani.Application.Admins.Services
{
    public interface IPeriocityService
    {
        Task<IReadOnlyList<PeriocityDto>> FindAllAsync();
        Task<PeriocityDto?> FindByIdAsync(int id);
        Task<PeriocityDto> CreateAsync(PeriocitySaveDto periocitySaveDto);
        Task<PeriocityDto> EditAsync(int id, PeriocitySaveDto periocitySaveDto);
        Task<PeriocityDto> DisabledAsync(int id);
    }
}
