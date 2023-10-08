using AutoMapper;
using Jazani.Taller.Aplication.Mc.Dtos.Investmenttypes;
using Jazani.Taller.Aplication.Mc.Dtos.MiningConcessions;
using Jazani.Taller.Domain.Mc.Models;
using Jazani.Taller.Domain.Mc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Taller.Aplication.Mc.Services.Implemetations
{
    public class MiningConcessionService : IMiningConcessionService
    {
        private readonly IMiningConcessionRepository _miniconRepository;
        private readonly IMapper _mapper;

        public MiningConcessionService(IMiningConcessionRepository miniRepository, IMapper mapper)
        {
            _miniconRepository = miniRepository;
            _mapper = mapper;
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
            MiningConcession minicon = await _miniconRepository.FindByIdAsync(id);
            minicon.State = false;

            MiningConcession auctionSaved = await _miniconRepository.SaveAsync(minicon);
            return _mapper.Map<MiningConcessionDto>(auctionSaved);
        }

        public async Task<MiningConcessionDto> EditAsync(int id, MiningConcessionSaveDto saveDto)
        {
            MiningConcession minicon = await _miniconRepository.FindByIdAsync(id);

            _mapper.Map<MiningConcessionSaveDto, MiningConcession>(saveDto, minicon);

            MiningConcession miniSaved = await _miniconRepository.SaveAsync(minicon);

            return _mapper.Map<MiningConcessionDto>(miniSaved);
        }

        public async Task<IReadOnlyList<MiningConcessionDto>> FindAllAsync()
        {
            IReadOnlyList<MiningConcession> invesme = await _miniconRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MiningConcessionDto>>(invesme);
        }

        public async Task<MiningConcessionDto?> FindByIdAsync(int id)
        {
            MiningConcession invesm = await _miniconRepository.FindByIdAsync(id);

            return _mapper.Map<MiningConcessionDto>(invesm);
        }
    }
}
