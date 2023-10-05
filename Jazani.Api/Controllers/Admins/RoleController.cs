using Jazani.Application.Admins.Dtos.Roles;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/<OfficeController>
        [HttpGet]
        public async Task<IEnumerable<RoleDto>> Get()
        {
            return await _roleService.FindAllAsync();
        }

        // GET api/<OfficeController>/5
        [HttpGet("{id}")]
        public async Task<RoleDto?> Get(int id)
        {
            return await _roleService.FindByIdAsync(id);
        }

        // POST api/<OfficeController>
        [HttpPost]
        public async Task<RoleDto> Post([FromBody] RoleSaveDto roleSaveDto)
        {
            return await _roleService.CreateAsync(roleSaveDto);
        }

        // PUT api/<OfficeController>/5
        [HttpPut("{id}")]
        public async Task<RoleDto> Put(int id, [FromBody] RoleSaveDto roleSaveDto)
        {
            return await _roleService.EditAsync(id, roleSaveDto);
        }

        // DELETE api/<OfficeController>/5
        [HttpDelete("{id}")]
        public async Task<RoleDto> Delete(int id)
        {
            return await _roleService.DisabledAsync(id);
        }

    }
}
