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


        public async Task<UserOfficeRoleBaseDto> CreateAsync(UserOfficeRoleSaveDto userOfficeRoleSaveDto)
        {
            UserOfficeRole userOfficeRole = _mapper.Map<UserOfficeRole>(userOfficeRoleSaveDto);
            userOfficeRole.RegistrationDate = DateTime.Now;
            userOfficeRole.State = true;
            await _userOfficeRoleRepository.SaveAsync(userOfficeRole);
            return _mapper.Map<UserOfficeRoleBaseDto>(userOfficeRole);
        }

        public async Task<UserOfficeRoleBaseDto> DisabledAsync(int UserId, int OfficeId, int RoleId)
        {
            UserOfficeRole userOfficeRole = await _userOfficeRoleRepository.FindByIdAsync(UserId, OfficeId, RoleId);
            userOfficeRole.State = false;
            UserOfficeRole userOfficeRoleSaved = await _userOfficeRoleRepository.SaveAsync(userOfficeRole);
            return _mapper.Map<UserOfficeRoleBaseDto>(userOfficeRoleSaved);
        }

        public async Task<UserOfficeRoleBaseDto> EditAsync(int UserId, int OfficeId, int RoleId, UserOfficeRoleSaveDto userOfficeRoleSaveDto)
        {
            UserOfficeRole userOfficeRole = await _userOfficeRoleRepository.FindByIdAsync(UserId, OfficeId, RoleId);
            _mapper.Map<UserOfficeRoleSaveDto, UserOfficeRole>(userOfficeRoleSaveDto, userOfficeRole);
            UserOfficeRole userOfficeRoleSaved = await _userOfficeRoleRepository.SaveAsync(userOfficeRole);
            return _mapper.Map<UserOfficeRoleBaseDto>(userOfficeRoleSaved);
        }

        public async Task<IReadOnlyList<UserOfficeRoleDto>> FindAllAsync()
        {
            IReadOnlyList<UserOfficeRole> roles = await _userOfficeRoleRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<UserOfficeRoleDto>>(roles);
        }

        public async Task<UserOfficeRoleDto?> FindByIdAsync(int UserId, int OfficeId, int RoleId)
        {
            UserOfficeRole role = await _userOfficeRoleRepository.FindByIdAsync(UserId, OfficeId, RoleId);
            return _mapper.Map<UserOfficeRoleDto?>(role);
        }
    }
}
