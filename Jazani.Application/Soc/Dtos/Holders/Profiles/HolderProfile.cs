using AutoMapper;
using Jazani.Domain.Soc.Models;

namespace Jazani.Application.Soc.Dtos.Holders.Profiles
{
    public class HolderProfile : Profile
    {
        public HolderProfile()
        {
            CreateMap<Holder, HolderDto>();
            CreateMap<Holder, HolderSimpleDto>();
        }
    }
}
