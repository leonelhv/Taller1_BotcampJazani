using Jazani.Taller.Aplication.Ge.Dtos.PeriodTypes;

namespace Jazani.Taller.Aplication.Ge.Services
{
    public interface IPeriodTypeService
    {
        Task<IReadOnlyList<PeriodTypeDto>> FindAllAsync();
        Task<PeriodTypeDto?> FindByIdAsync(int id);
        Task<PeriodTypeDto> CreateAsync(PeriodTypeSaveDto periodDto);
        Task<PeriodTypeDto> EditAsync(int id, PeriodTypeSaveDto periodSaveDto);
        Task<PeriodTypeDto> DisabledAsync(int id);

    }
}
