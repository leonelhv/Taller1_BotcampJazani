using AutoMapper;
using Jazani.Application.Cores.Contexts.Exceptions;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Jazani.Taller.Aplication.Mc.Dtos.Investments;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Mc.Services.Implementations
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentService> _logger;

        public InvestmentService(IInvestmentRepository investmentRepository, IMapper mapper, ILogger<InvestmentService> logger)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InvestmentDto> CreateAsync(InvestmentSaveDto investmentSave)
        {
            Investment invesment = _mapper.Map<Investment>(investmentSave);
            invesment.RegistrationDate = DateTime.Now;
            invesment.State = true;

            Investment newRecord = await _investmentRepository.SaveAsync(invesment);

            return _mapper.Map<InvestmentDto>(newRecord);
        }

        public async Task<InvestmentDto> DisabledAsync(int id)
        {
            Investment? invesment = await _investmentRepository.FindByIdAsync(id);

            if (invesment is null) throw InvesmentNotFound(id);
            invesment.State = false;

            Investment modifiedRecord = await _investmentRepository.SaveAsync(invesment);

            return _mapper.Map<InvestmentDto>(modifiedRecord);
        }

        public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSave)
        {
            Investment? invesment = await _investmentRepository.FindByIdAsync(id);

            if (invesment is null) throw InvesmentNotFound(id);

            _mapper.Map<InvestmentSaveDto, Investment>(investmentSave, invesment);

            Investment invesmentModify = await _investmentRepository.SaveAsync(invesment);

            return _mapper.Map<InvestmentDto>(invesmentModify);
        }

        public async Task<IReadOnlyList<InvestmentDto>> FindAllAsync()
        {
            return _mapper.Map<IReadOnlyList<InvestmentDto>>(await _investmentRepository.FindAllAsync());
        }

        public async Task<InvestmentDto?> FindByIdAsync(int id)
        {
            Investment? investment = await _investmentRepository.FindByIdAsync(id);

            if (investment is null)
            {
                _logger.LogWarning("Invesment no encontrado para el id: " + id);
                throw InvesmentNotFound(id);
            }

            _logger.LogInformation("Invesment su HolderId es {holderid}: ", investment.HolderId);


            return _mapper.Map<InvestmentDto>(investment);
        }

        private NoteFoundCoreException InvesmentNotFound(int id)
        {
            return new NoteFoundCoreException("Invesment no encontrado para el id: " + id);
        }

    }
}
