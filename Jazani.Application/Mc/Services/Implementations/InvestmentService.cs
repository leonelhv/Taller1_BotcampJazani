using AutoMapper;
using Jazani.Domain.Mc.Models;
using Jazani.Domain.Mc.Repositories;
using Jazani.Taller.Aplication.Mc.Dtos.Investments;

namespace Jazani.Application.Mc.Services.Implementations
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;

        public InvestmentService(IInvestmentRepository investmentRepository, IMapper mapper)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
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
            invesment.State = false;

            Investment modifiedRecord = await _investmentRepository.SaveAsync(invesment);

            return _mapper.Map<InvestmentDto>(modifiedRecord);
        }

        public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSave)
        {
            Investment? invesment = await _investmentRepository.FindByIdAsync(id);

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
            return _mapper.Map<InvestmentDto>(await _investmentRepository.FindByIdAsync(id));
        }


    }
}
