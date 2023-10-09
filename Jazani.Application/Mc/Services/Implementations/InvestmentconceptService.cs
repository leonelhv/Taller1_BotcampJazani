using AutoMapper;
using Jazani.Application.Cores.Contexts.Exceptions;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Jazani.Taller.Aplication.Mc.Dtos.Investmentconcepts;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Mc.Services.Implementations;
public class InvestmentconceptService : IInvestmentconceptService
{
    private readonly IInvestmentconceptRepository _investmentconceptRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<InvestmentconceptService> _logger;

    public InvestmentconceptService(IInvestmentconceptRepository investmentconceptRepository, IMapper mapper, ILogger<InvestmentconceptService> logger)
    {
        _investmentconceptRepository = investmentconceptRepository;
        _mapper = mapper;
        _logger = logger;
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
        if (invesconc is null) throw InvestmentconceptNotFound(id);
        invesconc.State = false;

        Investmentconcept modifiedRecord = await _investmentconceptRepository.SaveAsync(invesconc);

        return _mapper.Map<InvestmentconceptDto>(modifiedRecord);
    }

    public async Task<InvestmentconceptDto> EditAsync(int id, InvestmentconceptSaveDto investmentconceptSave)
    {
        Investmentconcept? invesconc = await _investmentconceptRepository.FindByIdAsync(id);

        if (invesconc is null) throw InvestmentconceptNotFound(id);


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
        Investmentconcept? invesconc = await _investmentconceptRepository.FindByIdAsync(id);


        if (invesconc is null)
        {
            _logger.LogWarning("Investmentconcept no encontrado para el id: " + id);
            throw InvestmentconceptNotFound(id);
        }

        _logger.LogInformation("Investmentconcept su id es {InvestmentconceptId}: ", invesconc.Id);

        return _mapper.Map<InvestmentconceptDto>(invesconc);
    }


    private NoteFoundCoreException InvestmentconceptNotFound(int id)
    {
        return new NoteFoundCoreException("Investmentconcept no encontrado para el id: " + id);
    }
}
