using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.UserOfficeRoles.Profiles
{
    public class UserOfficeRoleProfile : Profile
    {
        public UserOfficeRoleProfile()
        {
            CreateMap<UserOfficeRole, UserOfficeRoleDto>();
            CreateMap<UserOfficeRole, UserOfficeRoleSaveDto>().ReverseMap();
        }
    }
}
