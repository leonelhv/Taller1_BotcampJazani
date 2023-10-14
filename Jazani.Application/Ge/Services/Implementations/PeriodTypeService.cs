using AutoMapper;
using Jazani.Application.Cores.Contexts.Exceptions;
using Jazani.Domain.Ge.Models;
using Jazani.Domain.Ge.Repositories;
using Jazani.Taller.Aplication.Ge.Dtos.PeriodTypes;
using Microsoft.Extensions.Logging;

namespace Jazani.Taller.Aplication.Ge.Services.Implementations
{
    public class PeriodTypeService : IPeriodTypeService
    {
        private readonly IPeriodTypeRepository _periodRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PeriodTypeService> _logger;

        public PeriodTypeService(IPeriodTypeRepository periodRepository, IMapper mapper, ILogger<PeriodTypeService> logger)
        {
            _periodRepository = periodRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PeriodTypeDto> CreateAsync(PeriodTypeSaveDto periodDto)
        {
            PeriodType period = _mapper.Map<PeriodType>(periodDto);
            period.RegistrationDate = DateTime.Now;
            period.State = true;

            PeriodType periodSaved = await _periodRepository.SaveAsync(period);
            return _mapper.Map<PeriodTypeDto>(periodSaved);
        }

        public async Task<PeriodTypeDto> DisabledAsync(int id)
        {
            PeriodType? period = await _periodRepository.FindByIdAsync(id);
            if (period is null) throw PeriodTypeNotFound(id);
            period.State = false;

            PeriodType periodSaved = await _periodRepository.SaveAsync(period);

            return _mapper.Map<PeriodTypeDto>(periodSaved);
        }

        public async Task<PeriodTypeDto> EditAsync(int id, PeriodTypeSaveDto periodSaveDto)
        {
            PeriodType? period = await _periodRepository.FindByIdAsync(id);

            if (period is null) throw PeriodTypeNotFound(id);

            _mapper.Map<PeriodTypeSaveDto, PeriodType>(periodSaveDto, period);

            PeriodType perioSaved = await _periodRepository.SaveAsync(period);

            return _mapper.Map<PeriodTypeDto>(perioSaved);
        }

        public async Task<IReadOnlyList<PeriodTypeDto>> FindAllAsync()
        {
            IReadOnlyList<PeriodType> period = await _periodRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<PeriodTypeDto>>(period);
        }

        public async Task<PeriodTypeDto?> FindByIdAsync(int id)
        {
            PeriodType? period = await _periodRepository.FindByIdAsync(id);

            if (period is null)
            {
                _logger.LogWarning("PeriodType no encontrado para el id: " + id);
                throw PeriodTypeNotFound(id);
            }

            _logger.LogInformation("PeriodType su es {periodId}: ", period.Id);

            return _mapper.Map<PeriodTypeDto>(period);

        }

        private NoteFoundCoreException PeriodTypeNotFound(int id)
        {
            return new NoteFoundCoreException("PeriodType no encontrado para el id: " + id);
        }
    }
}
