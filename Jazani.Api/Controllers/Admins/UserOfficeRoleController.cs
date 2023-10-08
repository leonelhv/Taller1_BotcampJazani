using Jazani.Application.Admins.Dtos.UserOfficeRoles;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOfficeRoleController : ControllerBase
    {

        private readonly IUserOfficeRoleService _userOfficeRoleService;

        public UserOfficeRoleController(IUserOfficeRoleService userOfficeRoleService)
        {
            _userOfficeRoleService = userOfficeRoleService;
        }

        // GET: api/<PeriocityController>
        [HttpGet]
        public async Task<IEnumerable<UserOfficeRoleDto>> Get()
        {
            return await _userOfficeRoleService.FindAllAsync();
        }

        // GET api/<PeriocityController>/5
        [HttpGet("{id}")]
        public async Task<UserOfficeRoleDto?> Get(int id)
        {
            return await _userOfficeRoleService.FindByIdAsync(id);
        }

        // POST api/<PeriocityController>
        [HttpPost]
        public async Task<UserOfficeRoleDto> Post([FromBody] UserOfficeRoleSaveDto userOfficeRoleSaveDto)
        {
            return await _userOfficeRoleService.CreateAsync(userOfficeRoleSaveDto);
        }

        // PUT api/<PeriocityController>/5
        [HttpPut("{id}")]
        public async Task<UserOfficeRoleDto> Put(int id, [FromBody] UserOfficeRoleSaveDto userOfficeRoleSaveDto)
        {
            return await _userOfficeRoleService.EditAsync(id, userOfficeRoleSaveDto);
        }

        // DELETE api/<PeriocityController>/5
        [HttpDelete("{id}")]
        public async Task<UserOfficeRoleDto> Delete(int id)
        {
            return await _userOfficeRoleService.DisabledAsync(id);
        }

    }
}
