using Jazani.Application.Mc.Services;
using Jazani.Taller.Aplication.Mc.Dtos.Investments;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mc
{

    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<InvestmentDto>> Get()
        {
            return await _investmentService.FindAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<InvestmentDto?> Get(int id)
        {
            return await _investmentService.FindByIdAsync(id);
        }

        [HttpPost()]
        public async Task<InvestmentDto> Post([FromBody] InvestmentSaveDto investmentSave)
        {
            return await _investmentService.CreateAsync(investmentSave);
        }

        [HttpPut("{id}")]
        public async Task<InvestmentDto> Put(int id, [FromBody] InvestmentSaveDto investmentSave)
        {
            return await _investmentService.EditAsync(id, investmentSave);
        }

        [HttpDelete("{id}")]
        public async Task<InvestmentDto> Disabled(int id)
        {
            return await _investmentService.DisabledAsync(id);
        }
    }
}