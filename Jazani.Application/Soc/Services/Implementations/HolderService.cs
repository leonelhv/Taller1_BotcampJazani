using AutoMapper;
using Jazani.Application.Soc.Dtos.Holders;
using Jazani.Domain.Soc.Models;
using Jazani.Domain.Soc.Repositories;

namespace Jazani.Application.Soc.Services.Implementations
{
    public class HolderService : IHolderService
    {
        private readonly IHolderRepository _holderRepository;
        private readonly IMapper _mapper;

        public HolderService(IHolderRepository holderRepository, IMapper mapper)
        {
            _holderRepository = holderRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<HolderDto>> FindAllAsync()
        {
            IReadOnlyList<Holder> holer = await _holderRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<HolderDto>>(holer);
        }

        public async Task<HolderDto> FindByIdAsync(int id)
        {
            Holder holder = await _holderRepository.FindByIdAsync(id);
            return _mapper.Map<HolderDto>(holder);

        }
    }
}
