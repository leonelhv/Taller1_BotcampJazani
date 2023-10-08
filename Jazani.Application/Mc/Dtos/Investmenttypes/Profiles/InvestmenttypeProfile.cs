using AutoMapper;
using Jazani.Taller.Domain.Mc.Models;

namespace Jazani.Taller.Aplication.Mc.Dtos.Investmenttypes.Profiles
{
    public class InvestmenttypeProfile : Profile
    {
        public InvestmenttypeProfile()
        {
            CreateMap<Investmenttype, InvestmenttypeDto>();
            CreateMap<Investmenttype, InvestmenttypeSaveDto>().ReverseMap();
            CreateMap<Investmenttype, InvestmenttypeSimpleDto>().ReverseMap();
        }

    }
}
