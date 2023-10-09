using AutoMapper;
using Jazani.Application.Cores.Contexts.Exceptions;
using Jazani.Taller.Aplication.Mc.Dtos.Investmenttypes;
using Jazani.Taller.Domain.Mc.Models;
using Jazani.Taller.Domain.Mc.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Taller.Aplication.Mc.Services.Implemetations
{
    public class InvestmenttypeService : IInvestmenttypeService
    {
        private readonly IInvestmenttypeRepository _investtypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmenttypeService> _logger;

        public InvestmenttypeService(IInvestmenttypeRepository investypeRepository, IMapper mapper, ILogger<InvestmenttypeService> logger)
        {
            _investtypeRepository = investypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InvestmenttypeDto> CreateAsync(InvestmenttypeSaveDto saveDto)
        {
            Investmenttype invesme = _mapper.Map<Investmenttype>(saveDto);
            invesme.RegistrationDate = DateTime.Now;
            invesme.State = true;

            Investmenttype invesmeSaved = await _investtypeRepository.SaveAsync(invesme);
            return _mapper.Map<InvestmenttypeDto>(invesmeSaved);
        }

        public async Task<InvestmenttypeDto> DisabledAsync(int id)
        {
            Investmenttype? invesme = await _investtypeRepository.FindByIdAsync(id);
            if (invesme is null) throw InvestmenttypeNotFound(id);
            invesme.State = false;

            Investmenttype auctionSaved = await _investtypeRepository.SaveAsync(invesme);
            return _mapper.Map<InvestmenttypeDto>(auctionSaved);
        }

        public async Task<InvestmenttypeDto> EditAsync(int id, InvestmenttypeSaveDto saveDto)
        {
            Investmenttype? invesme = await _investtypeRepository.FindByIdAsync(id);

            if (invesme is null) throw InvestmenttypeNotFound(id);


            _mapper.Map<InvestmenttypeSaveDto, Investmenttype>(saveDto, invesme);

            Investmenttype invesmSaved = await _investtypeRepository.SaveAsync(invesme);

            return _mapper.Map<InvestmenttypeDto>(invesmSaved);
        }

        public async Task<IReadOnlyList<InvestmenttypeDto>> FindAllAsync()
        {
            IReadOnlyList<Investmenttype> invesme = await _investtypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmenttypeDto>>(invesme);
        }

        public async Task<InvestmenttypeDto?> FindByIdAsync(int id)
        {
            Investmenttype? invesm = await _investtypeRepository.FindByIdAsync(id);

            if (invesm is null)
            {
                _logger.LogWarning("Investmenttype no encontrado para el id: " + id);
                throw InvestmenttypeNotFound(id);
            }

            _logger.LogInformation("Investmenttype su id es {Investmenttypeid}: ", invesm.Id);

            return _mapper.Map<InvestmenttypeDto>(invesm);
        }

        private NoteFoundCoreException InvestmenttypeNotFound(int id)
        {
            return new NoteFoundCoreException("Investmenttype no encontrado para el id: " + id);
        }
    }
}
