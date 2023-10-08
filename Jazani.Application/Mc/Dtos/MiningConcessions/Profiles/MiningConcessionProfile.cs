using AutoMapper;
using Jazani.Taller.Domain.Mc.Models;

namespace Jazani.Taller.Aplication.Mc.Dtos.MiningConcessions.Profiles
{
    public class MiningConcessionProfile : Profile
    {
        public MiningConcessionProfile()
        {
            CreateMap<MiningConcession, MiningConcessionDto>();
            CreateMap<MiningConcession, MiningConcessionSaveDto>().ReverseMap();
            CreateMap<MiningConcession, MiningConcessionSimpleDto>().ReverseMap();

        }
    }
}
