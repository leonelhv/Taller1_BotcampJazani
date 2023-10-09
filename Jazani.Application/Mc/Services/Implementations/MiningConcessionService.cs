using AutoMapper;
using Jazani.Application.Cores.Contexts.Exceptions;
using Jazani.Taller.Aplication.Mc.Dtos.MiningConcessions;
using Jazani.Taller.Domain.Mc.Models;
using Jazani.Taller.Domain.Mc.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Taller.Aplication.Mc.Services.Implemetations
{
    public class MiningConcessionService : IMiningConcessionService
    {
        private readonly IMiningConcessionRepository _miniconRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MiningConcessionService> _logger;

        public MiningConcessionService(IMiningConcessionRepository miniRepository, IMapper mapper, ILogger<MiningConcessionService> logger)
        {
            _miniconRepository = miniRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<MiningConcessionDto> CreateAsync(MiningConcessionSaveDto saveDto)
        {
            MiningConcession minicon = _mapper.Map<MiningConcession>(saveDto);
            minicon.RegistrationDate = DateTime.Now;
            minicon.State = true;

            MiningConcession miniconSaved = await _miniconRepository.SaveAsync(minicon);
            return _mapper.Map<MiningConcessionDto>(miniconSaved);
        }

        public async Task<MiningConcessionDto> DisabledAsync(int id)
        {
            MiningConcession? minicon = await _miniconRepository.FindByIdAsync(id);
            if (minicon is null) throw MiningConcessionNotFound(id);
            minicon.State = false;

            MiningConcession auctionSaved = await _miniconRepository.SaveAsync(minicon);
            return _mapper.Map<MiningConcessionDto>(auctionSaved);
        }

        public async Task<MiningConcessionDto> EditAsync(int id, MiningConcessionSaveDto saveDto)
        {
            MiningConcession? minicon = await _miniconRepository.FindByIdAsync(id);

            if (minicon is null) throw MiningConcessionNotFound(id);

            _mapper.Map<MiningConcessionSaveDto, MiningConcession>(saveDto, minicon);

            MiningConcession miniSaved = await _miniconRepository.SaveAsync(minicon);

            return _mapper.Map<MiningConcessionDto>(miniSaved);
        }

        public async Task<IReadOnlyList<MiningConcessionDto>> FindAllAsync()
        {
            IReadOnlyList<MiningConcession> minicon = await _miniconRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MiningConcessionDto>>(minicon);
        }

        public async Task<MiningConcessionDto?> FindByIdAsync(int id)
        {
            MiningConcession? minicon = await _miniconRepository.FindByIdAsync(id);

            if (minicon is null)
            {
                _logger.LogWarning("MiningConcession no encontrado para el id: " + id);
                throw MiningConcessionNotFound(id);
            }

            _logger.LogInformation("MiningConcession su id es {MiningConcessionid}: ", minicon.Id);

            return _mapper.Map<MiningConcessionDto>(minicon);
        }

        private NoteFoundCoreException MiningConcessionNotFound(int id)
        {
            return new NoteFoundCoreException("MiningConcession no encontrado para el id: " + id);
        }
    }
}
