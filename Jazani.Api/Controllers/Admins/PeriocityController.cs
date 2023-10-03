using Jazani.Application.Admins.Dtos.Periocities;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriocityController : ControllerBase
    {
        private readonly IPeriocityService _periocityService;

        public PeriocityController(IPeriocityService periocityService)
        {
            _periocityService = periocityService;
        }

        // GET: api/<PeriocityController>
        [HttpGet]
        public async Task<IEnumerable<PeriocityDto>> Get()
        {
            return await _periocityService.FindAllAsync();
        }

        // GET api/<PeriocityController>/5
        [HttpGet("{id}")]
        public async Task<PeriocityDto?> Get(int id)
        {
            return await _periocityService.FindByIdAsync(id);
        }

        // POST api/<PeriocityController>
        [HttpPost]
        public async Task<PeriocityDto> Post([FromBody] PeriocitySaveDto periocitySaveDto)
        {
            return await _periocityService.CreateAsync(periocitySaveDto);
        }

        // PUT api/<PeriocityController>/5
        [HttpPut("{id}")]
        public async Task<PeriocityDto> Put(int id, [FromBody] PeriocitySaveDto periocitySaveDto)
        {
            return await _periocityService.EditAsync(id, periocitySaveDto);
        }

        // DELETE api/<PeriocityController>/5
        [HttpDelete("{id}")]
        public async Task<PeriocityDto> Delete(int id)
        {
            return await _periocityService.DisabledAsync(id);
        }
    }
}
