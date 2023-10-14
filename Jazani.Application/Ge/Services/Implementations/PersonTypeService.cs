using AutoMapper;
using Jazani.Application.Generals.Dtos.PersonTypes;
using Jazani.Core.Exceptions;
using Jazani.Domain.Ge.Models;
using Jazani.Domain.Ge.Repositories;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class PersonTypeService : IPersonTypeService
    {

        private readonly IPersonTypeRepository _personTypeRepository;
        private readonly IMapper _mapper;

        public PersonTypeService(IPersonTypeRepository personTypeRepository, IMapper mapper)
        {
            _personTypeRepository = personTypeRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<PersonTypeDto>> FindAllAsync()
        {
            IReadOnlyList<PersonType> personTypes = await _personTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<PersonTypeDto>>(personTypes);
        }

        public async Task<PersonTypeDto> FindByIdAsync(int id)
        {
            PersonType? personType = await _personTypeRepository.FindByIdAsync(id);

            if (personType is null) throw new NotFoundCoreException("Tipo de persona no encontrado para el id: " + id);

            return _mapper.Map<PersonTypeDto>(personType);
        }
    }
}

