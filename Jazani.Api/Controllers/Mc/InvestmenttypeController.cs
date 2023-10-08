using Jazani.Taller.Aplication.Mc.Dtos.Investmenttypes;
using Jazani.Taller.Aplication.Mc.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Mc
{

    [Route("api/[controller]")]
    [ApiController]
    public class InvestmenttypeController : ControllerBase
    {
        private readonly IInvestmenttypeService _invesmenService;
        public InvestmenttypeController(IInvestmenttypeService invesmeService)
        {
            _invesmenService = invesmeService;
        }


        // GET: api/<InvestmenttypeController>
        [HttpGet]
        public async Task<IEnumerable<InvestmenttypeDto>> Get()
        {
            return await _invesmenService.FindAllAsync();
        }

        // GET api/<InvestmenttypeController>/5
        [HttpGet("{id}")]
        public async Task<InvestmenttypeDto> Get(int id)
        {
            return await _invesmenService.FindByIdAsync(id);
        }

        // POST api/<InvestmenttypeController>
        [HttpPost]
        public async Task<InvestmenttypeDto> Post([FromBody] InvestmenttypeSaveDto invesSaveDto)
        {
            return await _invesmenService.CreateAsync(invesSaveDto);
        }

        // PUT api/<InvestmenttypeController>/5
        [HttpPut("{id}")]
        public async Task<InvestmenttypeDto> Put(int id, [FromBody] InvestmenttypeSaveDto invesmeSaveDto)
        {
            return await _invesmenService.EditAsync(id, invesmeSaveDto);
        }

        // DELETE api/<InvestmenttypeController>/5
        [HttpDelete("{id}")]
        public async Task<InvestmenttypeDto> Delete(int id)
        {
            return await _invesmenService.DisabledAsync(id);
        }
    }
}
