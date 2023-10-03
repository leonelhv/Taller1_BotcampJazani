

using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Users.Mappers
{
    public class UserSaveMapper : Profile
    {
        public UserSaveMapper()
        {
            CreateMap<User, UserSaveDto>().ReverseMap();
        }
    }
}
