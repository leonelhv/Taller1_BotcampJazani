using Jazani.Taller.Aplication.Mc.Dtos.MiningConcessions;

namespace Jazani.Taller.Aplication.Mc.Services
{
    public interface IMiningConcessionService
    {
        Task<IReadOnlyList<MiningConcessionDto>> FindAllAsync();
        Task<MiningConcessionDto?> FindByIdAsync(int id);
        Task<MiningConcessionDto> CreateAsync(MiningConcessionSaveDto miningConcSaveDto);
        Task<MiningConcessionDto> EditAsync(int id, MiningConcessionSaveDto miningConcSaveDto);
        Task<MiningConcessionDto> DisabledAsync(int id);

    }
}
