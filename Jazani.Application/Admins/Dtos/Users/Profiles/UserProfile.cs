using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Users.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UsersDto>();
            CreateMap<User, UserSimpleDto>();
            CreateMap<User, UsersSaveDto>().ReverseMap();
        }
    }
}
