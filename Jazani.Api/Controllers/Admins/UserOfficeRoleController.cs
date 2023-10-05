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
        [HttpGet("{UserId}/{OfficeId}/{RoleId}")]
        public async Task<UserOfficeRoleDto?> Get(int UserId, int OfficeId, int RoleId)
        {
            return await _userOfficeRoleService.FindByIdAsync(UserId, OfficeId, RoleId);
        }

        // POST api/<PeriocityController>
        [HttpPost]
        public async Task<UserOfficeRoleBaseDto> Post([FromBody] UserOfficeRoleSaveDto userOfficeRoleSaveDto)
        {
            return await _userOfficeRoleService.CreateAsync(userOfficeRoleSaveDto);
        }

        // PUT api/<PeriocityController>/5
        [HttpPut("{UserId}/{OfficeId}/{RoleId}")]
        public async Task<UserOfficeRoleBaseDto> Put(int UserId, int OfficeId, int RoleId, [FromBody] UserOfficeRoleSaveDto userOfficeRoleSaveDto)
        {
            return await _userOfficeRoleService.EditAsync(UserId, OfficeId, RoleId, userOfficeRoleSaveDto);
        }

        // DELETE api/<PeriocityController>/5
        [HttpDelete("{UserId}/{OfficeId}/{RoleId}")]
        public async Task<UserOfficeRoleBaseDto> Delete(int UserId, int OfficeId, int RoleId)
        {
            return await _userOfficeRoleService.DisabledAsync(UserId, OfficeId, RoleId);
        }

    }
}
