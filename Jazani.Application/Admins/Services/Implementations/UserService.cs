using AutoMapper;
using Jazani.Application.Admins.Dtos.Users;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<UsersDto>> FindAllAsync()
        {
            IReadOnlyList<User> users = await _userRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<UsersDto>>(users);
        }

        public async Task<UsersDto?> FindByIdAsync(int id)
        {
            User? user = await _userRepository.FindByIdAsync(id);
            return _mapper.Map<UsersDto?>(user);
        }
        public async Task<UsersDto> CreateAsync(UsersSaveDto userSaveDto)
        {
            User user = _mapper.Map<User>(userSaveDto);
            user.RegistrationDate = DateTime.Now;
            user.State = true;
            user.LdapAuthentication = false;
            user.NotificationCount = 0;
            user.IsInspector = 0;
            user.Password = PasswordHasher.HashPassword(user.Password);

            await _userRepository.SaveAsync(user);

            return _mapper.Map<UsersDto>(user);
        }



        public async Task<UsersDto> EditAsync(int id, UsersSaveDto userSaveDto)
        {
            User user = await _userRepository.FindByIdAsync(id);

            _mapper.Map<UsersSaveDto, User>(userSaveDto, user);

            user.Password = PasswordHasher.HashPassword(user.Password);

            await _userRepository.SaveAsync(user);

            return _mapper.Map<UsersDto>(user);
        }
        public async Task<UsersDto> DisabledAsync(int id)
        {

            User user = await _userRepository.FindByIdAsync(id);
            user.State = false;

            User userSaved = await _userRepository.SaveAsync(user);

            return _mapper.Map<UsersDto>(userSaved);
        }




    }
}
