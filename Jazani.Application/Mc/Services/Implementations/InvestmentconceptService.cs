using AutoMapper;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Jazani.Taller.Aplication.Mc.Dtos.Investmentconcepts;

namespace Jazani.Application.Mc.Services.Implementations;
public class InvestmentconceptService : IInvestmentconceptService
{
    private readonly IInvestmentconceptRepository _investmentconceptRepository;
    private readonly IMapper _mapper;

    public InvestmentconceptService(IInvestmentconceptRepository investmentconceptRepository, IMapper mapper)
    {
        _investmentconceptRepository = investmentconceptRepository;
        _mapper = mapper;
    }

    public async Task<InvestmentconceptDto> CreateAsync(InvestmentconceptSaveDto investmentconceptSave)
    {
        Investmentconcept invesconc = _mapper.Map<Investmentconcept>(investmentconceptSave);
        invesconc.RegistrationDate = DateTime.Now;
        invesconc.State = true;

        Investmentconcept newRecord = await _investmentconceptRepository.SaveAsync(invesconc);

        return _mapper.Map<InvestmentconceptDto>(newRecord);
    }

    public async Task<InvestmentconceptDto> DisabledAsync(int id)
    {
        Investmentconcept? invesconc = await _investmentconceptRepository.FindByIdAsync(id);
        invesconc.State = false;

        Investmentconcept modifiedRecord = await _investmentconceptRepository.SaveAsync(invesconc);

        return _mapper.Map<InvestmentconceptDto>(modifiedRecord);
    }

    public async Task<InvestmentconceptDto> EditAsync(int id, InvestmentconceptSaveDto investmentconceptSave)
    {
        Investmentconcept? invesconc = await _investmentconceptRepository.FindByIdAsync(id);

        _mapper.Map<InvestmentconceptSaveDto, Investmentconcept>(investmentconceptSave, invesconc);

        Investmentconcept invesconcModify = await _investmentconceptRepository.SaveAsync(invesconc);

        return _mapper.Map<InvestmentconceptDto>(invesconcModify);
    }

    public async Task<IReadOnlyList<InvestmentconceptDto>> FindAllAsync()
    {
        return _mapper.Map<IReadOnlyList<InvestmentconceptDto>>(await _investmentconceptRepository.FindAllAsync());
    }

    public async Task<InvestmentconceptDto?> FindByIdAsync(int id)
    {
        return _mapper.Map<InvestmentconceptDto>(await _investmentconceptRepository.FindByIdAsync(id));
    }


}
