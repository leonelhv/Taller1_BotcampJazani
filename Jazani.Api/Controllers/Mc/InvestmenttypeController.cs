using Jazani.Api.Exceptions;
using Jazani.Taller.Aplication.Mc.Dtos.Investmenttypes;
using Jazani.Taller.Aplication.Mc.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mc
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvestmenttypeController : ControllerBase
    {
        private readonly IInvestmenttypeService _invesmenService;

        public InvestmenttypeController(IInvestmenttypeService invesmeService)
        {
            _invesmenService = invesmeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<InvestmenttypeDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<IEnumerable<InvestmenttypeDto>>>> Get()
        {
            var response = await _invesmenService.FindAllAsync();
            return TypedResults.Ok<IEnumerable<InvestmenttypeDto>>(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmenttypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmenttypeDto>>> Get(int id)
        {
            var response = await _invesmenService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmenttypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmenttypeDto>>> Post([FromBody] InvestmenttypeSaveDto invesSaveDto)
        {
            var response = await _invesmenService.CreateAsync(invesSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmenttypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, Ok<InvestmenttypeDto>>> Put(int id, [FromBody] InvestmenttypeSaveDto invesmeSaveDto)
        {
            var response = await _invesmenService.EditAsync(id, invesmeSaveDto);
            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmenttypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, Ok<InvestmenttypeDto>>> Delete(int id)
        {
            var response = await _invesmenService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
