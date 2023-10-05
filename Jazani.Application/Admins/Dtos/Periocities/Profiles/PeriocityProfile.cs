using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Periocities.Profiles
{
    public class PeriocityProfile : Profile
    {
        public PeriocityProfile()
        {

            CreateMap<Periocity, PeriocityDto>();
            CreateMap<Periocity, PeriocitySaveDto>().ReverseMap();
        }
    }
}
