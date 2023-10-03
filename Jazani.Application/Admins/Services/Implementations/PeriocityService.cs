

using AutoMapper;
using Jazani.Application.Admins.Dtos.Periocities;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class PeriocityService : IPeriocityService
    {
        private readonly IPeriocityRepository _periocityRepository;
        private readonly IMapper _mapper;


        public PeriocityService(IPeriocityRepository periocityRepository, IMapper mapper)
        {
            _periocityRepository = periocityRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<PeriocityDto>> FindAllAsync()
        {
            IReadOnlyList<Periocity> periocities = await _periocityRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<PeriocityDto>>(periocities);
        }

        public async Task<PeriocityDto?> FindByIdAsync(int id)
        {
            Periocity? office = await _periocityRepository.FindByIdAsync(id);
            return _mapper.Map<PeriocityDto?>(office);
        }
        public async Task<PeriocityDto> CreateAsync(PeriocitySaveDto periocitySaveDto)
        {
            Periocity office = _mapper.Map<Periocity>(periocitySaveDto);
            office.RegistrationDate = DateTimeOffset.Now;
            office.State = true;

            Periocity officeSaved = await _periocityRepository.SaveAsync(office);

            return _mapper.Map<PeriocityDto>(officeSaved);
        }
        public async Task<PeriocityDto> EditAsync(int id, PeriocitySaveDto periocitySaveDto)
        {
            Periocity periocity = await _periocityRepository.FindByIdAsync(id);

            _mapper.Map<PeriocitySaveDto, Periocity>(periocitySaveDto, periocity);

            Periocity officeSaved = await _periocityRepository.SaveAsync(periocity);

            return _mapper.Map<PeriocityDto>(officeSaved);
        }
        public async Task<PeriocityDto> DisabledAsync(int id)
        {
            Periocity periocity = await _periocityRepository.FindByIdAsync(id);
            periocity.State = false;

            Periocity officeSaved = await _periocityRepository.SaveAsync(periocity);

            return _mapper.Map<PeriocityDto>(officeSaved);
        }




    }
}
