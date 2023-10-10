using Jazani.Application.Cores.Services;
using Jazani.Application.Mc.Dtos.Investments;
using Jazani.Taller.Aplication.Mc.Dtos.Investments;

namespace Jazani.Application.Mc.Services
{
    public interface IInvestmentService : IPaginatedService<InvestmentDto, InvesmentFilterDto>
    {
        Task<IReadOnlyList<InvestmentDto>> FindAllAsync();
        Task<InvestmentDto?> FindByIdAsync(int id);
        Task<InvestmentDto> CreateAsync(InvestmentSaveDto investmentSaveDto);
        Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSaveDto);
        Task<InvestmentDto> DisabledAsync(int id);
    }
}
