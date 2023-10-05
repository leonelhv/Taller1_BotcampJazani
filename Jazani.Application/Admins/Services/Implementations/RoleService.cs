using AutoMapper;
using Jazani.Application.Admins.Dtos.Roles;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<RoleDto> CreateAsync(RoleSaveDto roleSaveDto)
        {
            Role role = _mapper.Map<Role>(roleSaveDto);
            role.RegistrationDate = DateTime.Now;
            role.State = true;
            await _roleRepository.SaveAsync(role);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> DisabledAsync(int id)
        {
            Role role = await _roleRepository.FindByIdAsync(id);
            role.State = false;
            await _roleRepository.SaveAsync(role);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> EditAsync(int id, RoleSaveDto roleSaveDto)
        {
            Role role = await _roleRepository.FindByIdAsync(id);
            _mapper.Map<RoleSaveDto, Role>(roleSaveDto, role);
            await _roleRepository.SaveAsync(role);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<IReadOnlyList<RoleDto>> FindAllAsync()
        {
            IReadOnlyList<Role> roles = await _roleRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<RoleDto>>(roles);
        }

        public async Task<RoleDto?> FindByIdAsync(int id)
        {
            Role role = await _roleRepository.FindByIdAsync(id);
            return _mapper.Map<RoleDto>(role);

        }
    }
}
