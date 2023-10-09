using AutoMapper;
using Jazani.Application.Cores.Contexts.Exceptions;
using Jazani.Taller.Aplication.Ge.Dtos.MeasureUnits;
using Jazani.Taller.Domain.Ge.Models;
using Jazani.Taller.Domain.Ge.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Taller.Aplication.Ge.Services.Implementations
{
    public class MeasureUnitService : IMeasureUnitService
    {
        private readonly IMeasureUnitRepository _measuRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MeasureUnitService> _logger;

        public MeasureUnitService(IMeasureUnitRepository auctRepository, IMapper mapper, ILogger<MeasureUnitService> logger)
        {
            _measuRepository = auctRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MeasureUnitDto> CreateAsync(MeasureUnitSaveDto measureSaveDto)
        {
            MeasureUnit measure = _mapper.Map<MeasureUnit>(measureSaveDto);
            measure.RegistrationDate = DateTime.Now;
            measure.State = true;

            MeasureUnit autiomSaved = await _measuRepository.SaveAsync(measure);
            return _mapper.Map<MeasureUnitDto>(autiomSaved);
        }

        public async Task<MeasureUnitDto> DisabledAsync(int id)
        {
            MeasureUnit? measure = await _measuRepository.FindByIdAsync(id);

            if (measure is null) throw MeasureUnitNotFound(id);

            measure.State = false;

            MeasureUnit measureSaved = await _measuRepository.SaveAsync(measure);

            return _mapper.Map<MeasureUnitDto>(measureSaved);
        }

        public async Task<MeasureUnitDto> EditAsync(int id, MeasureUnitSaveDto measureSaveDto)
        {
            MeasureUnit? measure = await _measuRepository.FindByIdAsync(id);

            if (measure is null) throw MeasureUnitNotFound(id);


            _mapper.Map<MeasureUnitSaveDto, MeasureUnit>(measureSaveDto, measure);

            MeasureUnit measureSaved = await _measuRepository.SaveAsync(measure);

            return _mapper.Map<MeasureUnitDto>(measureSaved);
        }

        public async Task<IReadOnlyList<MeasureUnitDto>> FindAllAsync()
        {
            IReadOnlyList<MeasureUnit> measure = await _measuRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MeasureUnitDto>>(measure);
        }

        public async Task<MeasureUnitDto?> FindByIdAsync(int id)
        {
            MeasureUnit? measure = await _measuRepository.FindByIdAsync(id);

            if (measure is null)
            {
                _logger.LogWarning("MeasureUnit no encontrado para el id: " + id);
                throw MeasureUnitNotFound(id);
            }

            _logger.LogInformation("MeasureUnit su id es {holderid}: ", measure.Id);


            return _mapper.Map<MeasureUnitDto>(measure);
        }

        private NoteFoundCoreException MeasureUnitNotFound(int id)
        {
            return new NoteFoundCoreException("MeasureUnit no encontrado para el id: " + id);
        }
    }
}
