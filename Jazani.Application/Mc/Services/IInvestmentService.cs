using Jazani.Taller.Aplication.Mc.Dtos.Investments;

namespace Jazani.Application.Mc.Services
{
    public interface IInvestmentService
    {
        Task<IReadOnlyList<InvestmentDto>> FindAllAsync();
        Task<InvestmentDto?> FindByIdAsync(int id);
        Task<InvestmentDto> CreateAsync(InvestmentSaveDto investmentSaveDto);
        Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSaveDto);
        Task<InvestmentDto> DisabledAsync(int id);
    }
}
