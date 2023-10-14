using AutoMapper;
using Jazani.Application.Admins.Dtos.Userjwts;
using Jazani.Core.Exceptions;
using Jazani.Core.Securities.Services;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Microsoft.Extensions.Configuration;


namespace Jazani.Application.Admins.Services.Implementations
{
    public class UserjwtService : IUserjwtService
    {
        private readonly IUserjwtRepository _userjwtRepository;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;
        private readonly IConfiguration _configuration;

        public UserjwtService(IUserjwtRepository userjwtRepository, IMapper mapper, ISecurityService securityService, IConfiguration configuration)
        {
            _userjwtRepository = userjwtRepository;
            _mapper = mapper;
            _securityService = securityService;
            _configuration = configuration;
        }

        public async Task<UserjwtDto> CreateAsync(UserjwtSaveDto saveDto)
        {
            Userjwt user = _mapper.Map<Userjwt>(saveDto);
            user.State = true;
            user.RegistrationDate = DateTime.Now;

            user.Password = _securityService.HashPassword(saveDto.Email, saveDto.Password);
            await _userjwtRepository.SaveAsync(user);
            return _mapper.Map<UserjwtDto>(user);
        }

        public Task<UserjwtDto> EditAsync(int id, UserjwtSaveDto saveDto)
        {
            throw new NotImplementedException();
        }
        public async Task<UserSecurityDto> LoginAsync(UserAuthDto userAuth)
        {
            Userjwt? user = await _userjwtRepository.FindByEmailAsync(userAuth.Email);

            if (user is null) throw new NotFoundCoreException("Usuario no esta registrado en nuestro Sistema");

            bool isCorrect = _securityService.VerifyHashedPassword(user.Email, user.Password, userAuth.Password);
            if (!isCorrect) throw new NotFoundCoreException("La contraseña que ingreso no es correcta");


            if (!user.State) throw new NotFoundCoreException("Usuario no esta activo. Comuniquese con el adminstrador");

            UserSecurityDto userSecurity = _mapper.Map<UserSecurityDto>(user);

            string jwtSecretKey = _configuration.GetSection("Security:JwtSecrectKey").Get<string>();

            userSecurity.Security = _securityService.JwtSecurity(jwtSecretKey);


            return userSecurity;
        }
    }
}
