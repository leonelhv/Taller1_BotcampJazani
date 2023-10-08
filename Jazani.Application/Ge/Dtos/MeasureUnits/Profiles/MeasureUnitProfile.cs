using AutoMapper;
using Jazani.Taller.Domain.Ge.Models;

namespace Jazani.Taller.Aplication.Ge.Dtos.MeasureUnits.Profiles
{
    public class MeasureUnitProfile : Profile
    {
        public MeasureUnitProfile()
        {
            CreateMap<MeasureUnit, MeasureUnitDto>();
            CreateMap<MeasureUnit, MeasureUnitSimpleDto>().ReverseMap();
            CreateMap<MeasureUnit, MeasureUnitSaveDto>().ReverseMap();

        }

    }
}
