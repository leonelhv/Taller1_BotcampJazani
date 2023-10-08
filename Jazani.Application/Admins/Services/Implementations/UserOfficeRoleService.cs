using AutoMapper;
using Jazani.Application.Admins.Dtos.UserOfficeRoles;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class UserOfficeRoleService : IUserOfficeRoleService
    {
        private readonly IUserOfficeRoleRepository _userOfficeRoleRepository;
        private readonly IMapper _mapper;

        public UserOfficeRoleService(IUserOfficeRoleRepository userOfficeRoleRepository, IMapper mapper)
        {
            _userOfficeRoleRepository = userOfficeRoleRepository;
            _mapper = mapper;
        }


        public async Task<UserOfficeRoleDto> CreateAsync(UserOfficeRoleSaveDto userOfficeRoleSaveDto)
        {
            UserOfficeRole userOfficeRole = _mapper.Map<UserOfficeRole>(userOfficeRoleSaveDto);
            userOfficeRole.RegistrationDate = DateTime.Now;
            userOfficeRole.State = true;
            await _userOfficeRoleRepository.SaveAsync(userOfficeRole);
            return _mapper.Map<UserOfficeRoleDto>(userOfficeRole);
        }

        public async Task<UserOfficeRoleDto> DisabledAsync(int id)
        {
            UserOfficeRole userOfficeRole = await _userOfficeRoleRepository.FindByIdAsync(id);
            userOfficeRole.State = false;
            UserOfficeRole userOfficeRoleSaved = await _userOfficeRoleRepository.SaveAsync(userOfficeRole);
            return _mapper.Map<UserOfficeRoleDto>(userOfficeRoleSaved);
        }


        public async Task<UserOfficeRoleDto> EditAsync(int id, UserOfficeRoleSaveDto userOfficeRoleSaveDto)
        {
            UserOfficeRole userOfficeRole = await _userOfficeRoleRepository.FindByIdAsync(id);
            _mapper.Map<UserOfficeRoleSaveDto, UserOfficeRole>(userOfficeRoleSaveDto, userOfficeRole);
            await _userOfficeRoleRepository.SaveAsync(userOfficeRole);
            return _mapper.Map<UserOfficeRoleDto>(userOfficeRole);
        }

        public async Task<IReadOnlyList<UserOfficeRoleDto>> FindAllAsync()
        {
            IReadOnlyList<UserOfficeRole> roles = await _userOfficeRoleRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<UserOfficeRoleDto>>(roles);
        }

        public async Task<UserOfficeRoleDto?> FindByIdAsync(int id)
        {
            UserOfficeRole role = await _userOfficeRoleRepository.FindByIdAsync(id);
            return _mapper.Map<UserOfficeRoleDto?>(role);
        }


    }
}
