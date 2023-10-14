using AutoMapper;
using Jazani.Domain.Ge.Models;

namespace Jazani.Taller.Aplication.Ge.Dtos.PeriodTypes.Profiles
{
    public class PeriodTypeProfile : Profile
    {
        public PeriodTypeProfile()
        {
            CreateMap<PeriodType, PeriodTypeDto>();
            CreateMap<PeriodType, PeriodTypeSimpleDto>().ReverseMap();
            CreateMap<PeriodType, PeriodTypeSaveDto>().ReverseMap();
        }
    }
}
