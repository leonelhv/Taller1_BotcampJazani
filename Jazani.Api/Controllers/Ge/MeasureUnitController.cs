using Jazani.Api.Exceptions;
using Jazani.Taller.Aplication.Ge.Dtos.MeasureUnits;
using Jazani.Taller.Aplication.Ge.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Ge
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MeasureUnitController : ControllerBase
    {
        private readonly IMeasureUnitService _measuService;

        public MeasureUnitController(IMeasureUnitService measuService)
        {
            _measuService = measuService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MeasureUnitDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<IEnumerable<MeasureUnitDto>>>> Get()
        {
            var response = await _measuService.FindAllAsync();
            return TypedResults.Ok<IEnumerable<MeasureUnitDto>>(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureUnitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MeasureUnitDto>>> Get(int id)
        {
            var response = await _measuService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MeasureUnitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MeasureUnitDto>>> Post([FromBody] MeasureUnitSaveDto measuSaveDto)
        {
            var response = await _measuService.CreateAsync(measuSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureUnitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, Ok<MeasureUnitDto>>> Put(int id, [FromBody] MeasureUnitSaveDto measuSaveDto)
        {
            var response = await _measuService.EditAsync(id, measuSaveDto);
            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureUnitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, Ok<MeasureUnitDto>>> Delete(int id)
        {
            var response = await _measuService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
