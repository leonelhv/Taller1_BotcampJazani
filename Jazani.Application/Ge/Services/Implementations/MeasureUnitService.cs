using AutoMapper;
using Jazani.Taller.Aplication.Ge.Dtos.MeasureUnits;
using Jazani.Taller.Domain.Ge.Models;
using Jazani.Taller.Domain.Ge.Repositories;

namespace Jazani.Taller.Aplication.Ge.Services.Implementations
{
    public class MeasureUnitService : IMeasureUnitService
    {
        private readonly IMeasureUnitRepository _measuRepository;
        private readonly IMapper _mapper;

        public MeasureUnitService(IMeasureUnitRepository auctRepository, IMapper mapper)
        {
            _measuRepository = auctRepository;
            _mapper = mapper;
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
            MeasureUnit measure = await _measuRepository.FindByIdAsync(id);
            measure.State = false;

            MeasureUnit measureSaved = await _measuRepository.SaveAsync(measure);

            return _mapper.Map<MeasureUnitDto>(measureSaved);
        }

        public async Task<MeasureUnitDto> EditAsync(int id, MeasureUnitSaveDto measureSaveDto)
        {
            MeasureUnit measure = await _measuRepository.FindByIdAsync(id);

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
            MeasureUnit measure = await _measuRepository.FindByIdAsync(id);

            return _mapper.Map<MeasureUnitDto>(measure);
        }
    }
}
