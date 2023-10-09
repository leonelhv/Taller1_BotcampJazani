using Jazani.Api.Exceptions;
using Jazani.Application.Mc.Services;
using Jazani.Taller.Aplication.Mc.Dtos.Investmentconcepts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mc
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvestmentconceptController : ControllerBase
    {
        private readonly IInvestmentconceptService _investmentconceptService;

        public InvestmentconceptController(IInvestmentconceptService investmentconceptService)
        {
            _investmentconceptService = investmentconceptService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<InvestmentconceptDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<IEnumerable<InvestmentconceptDto>>>> Get()
        {
            var response = await _investmentconceptService.FindAllAsync();
            return TypedResults.Ok<IEnumerable<InvestmentconceptDto>>(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentconceptDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentconceptDto>>> Get(int id)
        {
            var response = await _investmentconceptService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentconceptDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentconceptDto>>> Post([FromBody] InvestmentconceptSaveDto investmentconceptSave)
        {
            var response = await _investmentconceptService.CreateAsync(investmentconceptSave);
            return TypedResults.CreatedAtRoute(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentconceptDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, Ok<InvestmentconceptDto>>> Put(int id, [FromBody] InvestmentconceptSaveDto investmentconceptSave)
        {
            var response = await _investmentconceptService.EditAsync(id, investmentconceptSave);
            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentconceptDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, Ok<InvestmentconceptDto>>> Delete(int id)
        {
            var response = await _investmentconceptService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}