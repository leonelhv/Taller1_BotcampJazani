using Jazani.Taller.Aplication.Mc.Dtos.Investmenttypes;

namespace Jazani.Taller.Aplication.Mc.Services
{
    public interface IInvestmenttypeService
    {
        Task<IReadOnlyList<InvestmenttypeDto>> FindAllAsync();
        Task<InvestmenttypeDto?> FindByIdAsync(int id);
        Task<InvestmenttypeDto> CreateAsync(InvestmenttypeSaveDto saveDto);
        Task<InvestmenttypeDto> EditAsync(int id, InvestmenttypeSaveDto saveDto);
        Task<InvestmenttypeDto> DisabledAsync(int id);

    }
}
