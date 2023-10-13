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


        [HttpGet("{userId}/{officeId}/{roleId}")]
        public async Task<UserOfficeRoleDto?> Get(int userId, int officeId, int roleId)
        {
            return await _userOfficeRoleService.FindByIdAsync(userId, officeId, roleId);
        }


        [HttpPost]
        public async Task<UserOfficeRoleDto> Post([FromBody] UserOfficeRoleSaveDto userOfficeRoleSaveDto)
        {
            return await _userOfficeRoleService.CreateAsync(userOfficeRoleSaveDto);
        }

        [HttpPut("{userId}/{officeId}/{roleId}")]
        public async Task<UserOfficeRoleDto> Put(int userId, int officeId, int roleId)
        {
            return await _userOfficeRoleService.EditAsync(userId, officeId, roleId);
        }



        [HttpDelete("{userId}/{officeId}/{roleId}")]
        public async Task<UserOfficeRoleDto> Delete(int userId, int officeId, int roleId)
        {
            return await _userOfficeRoleService.DisabledAsync(userId, officeId, roleId);
        }


    }
}
