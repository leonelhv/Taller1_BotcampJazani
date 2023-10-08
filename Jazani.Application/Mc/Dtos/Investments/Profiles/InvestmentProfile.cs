using AutoMapper;
using Jazani.Domain.Mc.Models;

namespace Jazani.Taller.Aplication.Mc.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile()
        {
            CreateMap<Investment, InvestmentDto>();
            CreateMap<Investment, InvestmentSaveDto>().ReverseMap();

        }
    }
}
