using Jazani.Taller.Aplication.Ge.Dtos.MeasureUnits;

namespace Jazani.Taller.Aplication.Ge.Services
{
    public interface IMeasureUnitService
    {
        Task<IReadOnlyList<MeasureUnitDto>> FindAllAsync();
        Task<MeasureUnitDto?> FindByIdAsync(int id);
        Task<MeasureUnitDto> CreateAsync(MeasureUnitSaveDto measureSaveDto);
        Task<MeasureUnitDto> EditAsync(int id, MeasureUnitSaveDto measureSaveDto);
        Task<MeasureUnitDto> DisabledAsync(int id);

    }
}
