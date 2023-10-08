using AutoMapper;
using Jazani.Domain.Mc.Models;

namespace Jazani.Taller.Aplication.Mc.Dtos.Investmentconcepts.Profiles
{
    public class InvestmentconceptProfile : Profile
    {
        public InvestmentconceptProfile()
        {
            CreateMap<Investmentconcept, InvestmentconceptDto>();
            CreateMap<Investmentconcept, InvestmentconceptSimpleDto>().ReverseMap();
            CreateMap<Investmentconcept, InvestmentconceptSaveDto>().ReverseMap();

        }
    }
}
