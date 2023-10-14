using Jazani.Application.Admins.Dtos.Users;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IReadOnlyList<UsersDto>> Get()
        {
            return await _userService.FindAllAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UsersDto?> Get(int id)
        {
            return await _userService.FindByIdAsync(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<UsersDto> Post([FromBody] UsersSaveDto userSaveDto)
        {
            return await _userService.CreateAsync(userSaveDto);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<UsersDto> Put(int id, [FromBody] UsersSaveDto officeSaveDto)
        {
            return await _userService.EditAsync(id, officeSaveDto);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<UsersDto> Delete(int id)
        {
            return await _userService.DisabledAsync(id);
        }
    }
}
