using Jazani.Taller.Aplication.Ge.Dtos.MeasureUnits;
using Jazani.Taller.Aplication.Ge.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Ge
{

    [Route("api/[controller]")]
    [ApiController]
    public class MeasureUnitController : ControllerBase
    {
        private readonly IMeasureUnitService _measuService;
        public MeasureUnitController(IMeasureUnitService measuService)
        {
            _measuService = measuService;
        }

        // GET: api/<MeasureUnitController>
        [HttpGet]
        public async Task<IEnumerable<MeasureUnitDto>> Get()
        {
            return await _measuService.FindAllAsync();
        }

        // GET api/<MeasureUnitController>/5
        [HttpGet("{id}")]
        public async Task<MeasureUnitDto> Get(int id)
        {
            return await _measuService.FindByIdAsync(id);
        }

        // POST api/<MeasureUnitController>
        [HttpPost]
        public async Task<MeasureUnitDto> Post([FromBody] MeasureUnitSaveDto measuSaveDto)
        {
            return await _measuService.CreateAsync(measuSaveDto);
        }

        // PUT api/<MeasureUnitController>/5
        [HttpPut("{id}")]
        public async Task<MeasureUnitDto> Put(int id, [FromBody] MeasureUnitSaveDto measuSaveDto)
        {
            return await _measuService.EditAsync(id, measuSaveDto);
        }

        // DELETE api/<MeasureUnitController>/5
        [HttpDelete("{id}")]
        public async Task<MeasureUnitDto> Delete(int id)
        {
            return await _measuService.DisabledAsync(id);
        }
    }
}
