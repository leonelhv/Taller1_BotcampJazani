using AutoMapper;
using Jazani.Taller.Aplication.Ge.Dtos.PeriodTypes;
using Jazani.Taller.Domain.Ge.Models;
using Jazani.Taller.Domain.Ge.Repositories;

namespace Jazani.Taller.Aplication.Ge.Services.Implementations
{
    public class PeriodTypeService : IPeriodTypeService
    {
        private readonly IPeriodTypeRepository _periodRepository;
        private readonly IMapper _mapper;

        public PeriodTypeService(IPeriodTypeRepository periodRepository, IMapper mapper)
        {
            _periodRepository = periodRepository;
            _mapper = mapper;
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
            PeriodType period = await _periodRepository.FindByIdAsync(id);
            period.State = false;

            PeriodType periodSaved = await _periodRepository.SaveAsync(period);

            return _mapper.Map<PeriodTypeDto>(periodSaved);
        }

        public async Task<PeriodTypeDto> EditAsync(int id, PeriodTypeSaveDto periodSaveDto)
        {
            PeriodType period = await _periodRepository.FindByIdAsync(id);

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
            PeriodType period = await _periodRepository.FindByIdAsync(id);

            return _mapper.Map<PeriodTypeDto>(period);

        }
    }
}
