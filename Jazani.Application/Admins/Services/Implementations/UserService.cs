using AutoMapper;
using Jazani.Application.Admins.Dtos.Users;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using System.Security.Cryptography;
using System.Text;

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
        public async Task<IReadOnlyList<UserDto>> FindAllAsync()
        {
            IReadOnlyList<User> users = await _userRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<UserDto>>(users);
        }

        public async Task<UserDto?> FindByIdAsync(int id)
        {
            User? user = await _userRepository.FindByIdAsync(id);
            return _mapper.Map<UserDto?>(user);
        }
        public async Task<UserDto> CreateAsync(UserSaveDto userSaveDto)
        {
            User user = _mapper.Map<User>(userSaveDto);
            user.RegistrationDate = DateTimeOffset.Now;
            user.State = true;
            user.LdapAuthentication = false;
            user.Password = GetSHA1(user.Password);


            User userSaved = await _userRepository.SaveAsync(user);

            return _mapper.Map<UserDto>(userSaved);
        }



        public async Task<UserDto> EditAsync(int id, UserSaveDto userSaveDto)
        {
            User user = await _userRepository.FindByIdAsync(id);

            _mapper.Map<UserSaveDto, User>(userSaveDto, user);

            user.Password = GetSHA1(user.Password);

            User userSaved = await _userRepository.SaveAsync(user);

            return _mapper.Map<UserDto>(userSaved);
        }
        public async Task<UserDto> DisabledAsync(int id)
        {

            User user = await _userRepository.FindByIdAsync(id);
            user.State = false;

            User userSaved = await _userRepository.SaveAsync(user);

            return _mapper.Map<UserDto>(userSaved);
        }

        private static string GetSHA1(String texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }


    }
}
