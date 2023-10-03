

using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Periocities.Mappers
{
    public class PeriocitySaveMapper : Profile
    {
        public PeriocitySaveMapper()
        {

            CreateMap<Periocity, PeriocitySaveDto>().ReverseMap();
        }
    }
}
