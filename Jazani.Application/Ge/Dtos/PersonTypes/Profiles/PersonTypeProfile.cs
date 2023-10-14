using AutoMapper;
using Jazani.Domain.Ge.Models;

namespace Jazani.Application.Generals.Dtos.PersonTypes.Profiles
{
    public class PersonTypeProfile : Profile
    {
        public PersonTypeProfile()
        {
            CreateMap<PersonType, PersonTypeDto>();

            CreateMap<PersonType, PersonTypeSaveDto>().ReverseMap();
        }
    }
}

