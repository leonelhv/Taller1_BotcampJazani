using Jazani.Taller.Aplication.Mc.Dtos.MiningConcessions;
using Jazani.Taller.Aplication.Mc.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Mc
{

    [Route("api/[controller]")]
    [ApiController]
    public class MiningConcessionController : ControllerBase
    {
        private readonly IMiningConcessionService _miniconcService;
        public MiningConcessionController(IMiningConcessionService miniconcService)
        {
            _miniconcService = miniconcService;
        }

        // GET: api/<MiningConcessionController>
        [HttpGet]
        public async Task<IEnumerable<MiningConcessionDto>> Get()
        {
            return await _miniconcService.FindAllAsync();
        }

        // GET api/<MiningConcessionController>/5
        [HttpGet("{id}")]
        public async Task<MiningConcessionDto> Get(int id)
        {
            return await _miniconcService.FindByIdAsync(id);
        }

        // POST api/<MiningConcessionController>
        [HttpPost]
        public async Task<MiningConcessionDto> Post([FromBody] MiningConcessionSaveDto miningConcSaveDto)
        {
            return await _miniconcService.CreateAsync(miningConcSaveDto);
        }

        // PUT api/<MiningConcessionController>/5
        [HttpPut("{id}")]
        public async Task<MiningConcessionDto> Put(int id, [FromBody] MiningConcessionSaveDto miningConcSaveDto)
        {
            return await _miniconcService.EditAsync(id, miningConcSaveDto);
        }

        // DELETE api/<MiningConcessionController>/5
        [HttpDelete("{id}")]
        public async Task<MiningConcessionDto> Delete(int id)
        {
            return await _miniconcService.DisabledAsync(id);
        }
    }
}
