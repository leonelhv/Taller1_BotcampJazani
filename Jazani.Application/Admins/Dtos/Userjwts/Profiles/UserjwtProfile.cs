using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Userjwts.Profiles
{
    public class UserjwtProfile : Profile
    {
        public UserjwtProfile()
        {
            CreateMap<Userjwt, UserjwtDto>();
            CreateMap<Userjwt, UserSecurityDto>();
            CreateMap<Userjwt, UserjwtSaveDto>().ReverseMap();
        }
    }
}
