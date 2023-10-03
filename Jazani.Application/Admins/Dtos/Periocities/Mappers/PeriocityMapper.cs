

using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Periocities.Mappers
{
    public class PeriocityMapper : Profile
    {
        public PeriocityMapper()
        {
            CreateMap<Periocity, PeriocityDto>();
        }
    }
}
