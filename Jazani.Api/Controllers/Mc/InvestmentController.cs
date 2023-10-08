using Jazani.Api.Exceptions;
using Jazani.Application.Mc.Services;
using Jazani.Taller.Aplication.Mc.Dtos.Investments;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<InvestmentDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<IEnumerable<InvestmentDto>>>> Get()
        {
            var response = await _investmentService.FindAllAsync();
            return TypedResults.Ok<IEnumerable<InvestmentDto>>(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentDto>>> Get(int id)
        {
            var response = await _investmentService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentDto>>> Post([FromBody] InvestmentSaveDto investmentSave)
        {
            var response = await _investmentService.CreateAsync(investmentSave);
            return TypedResults.CreatedAtRoute(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, Ok<InvestmentDto>>> Put(int id, [FromBody] InvestmentSaveDto investmentSave)
        {
            var response = await _investmentService.EditAsync(id, investmentSave);
            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, Ok<InvestmentDto>>> Delete(int id)
        {
            var response = await _investmentService.DisabledAsync(id);
            return TypedResults.Ok(response);

        }
    }
}