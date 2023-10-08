using AutoMapper;
using Jazani.Taller.Aplication.Mc.Dtos.Investmenttypes;
using Jazani.Taller.Domain.Mc.Models;
using Jazani.Taller.Domain.Mc.Repositories;

namespace Jazani.Taller.Aplication.Mc.Services.Implemetations
{
    public class InvestmenttypeService : IInvestmenttypeService
    {
        private readonly IInvestmenttypeRepository _investtypeRepository;
        private readonly IMapper _mapper;

        public InvestmenttypeService(IInvestmenttypeRepository investypeRepository, IMapper mapper)
        {
            _investtypeRepository = investypeRepository;
            _mapper = mapper;
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
            Investmenttype invesme = await _investtypeRepository.FindByIdAsync(id);
            invesme.State = false;

            Investmenttype auctionSaved = await _investtypeRepository.SaveAsync(invesme);
            return _mapper.Map<InvestmenttypeDto>(auctionSaved);
        }

        public async Task<InvestmenttypeDto> EditAsync(int id, InvestmenttypeSaveDto saveDto)
        {
            Investmenttype invesme = await _investtypeRepository.FindByIdAsync(id);

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
            Investmenttype invesm = await _investtypeRepository.FindByIdAsync(id);

            return _mapper.Map<InvestmenttypeDto>(invesm);
        }
    }
}
