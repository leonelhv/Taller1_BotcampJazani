using Jazani.Api.Exceptions;
using Jazani.Taller.Aplication.Ge.Dtos.PeriodTypes;
using Jazani.Taller.Aplication.Ge.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Ge
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PeriodTypeController : ControllerBase
    {
        private readonly IPeriodTypeService _periodService;

        public PeriodTypeController(IPeriodTypeService perioService)
        {
            _periodService = perioService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PeriodTypeDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<IEnumerable<PeriodTypeDto>>>> Get()
        {
            var response = await _periodService.FindAllAsync();
            return TypedResults.Ok<IEnumerable<PeriodTypeDto>>(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<PeriodTypeDto>>> Get(int id)
        {
            var response = await _periodService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PeriodTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<PeriodTypeDto>>> Post([FromBody] PeriodTypeSaveDto periodSaveDto)
        {
            var response = await _periodService.CreateAsync(periodSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, Ok<PeriodTypeDto>>> Put(int id, [FromBody] PeriodTypeSaveDto periodSaveDto)
        {
            var response = await _periodService.EditAsync(id, periodSaveDto);
            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, Ok<PeriodTypeDto>>> Delete(int id)
        {
            var response = await _periodService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
