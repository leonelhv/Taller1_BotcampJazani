using Jazani.Api.Exceptions;
using Jazani.Taller.Aplication.Mc.Dtos.MiningConcessions;
using Jazani.Taller.Aplication.Mc.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mc
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MiningConcessionController : ControllerBase
    {
        private readonly IMiningConcessionService _miniconcService;

        public MiningConcessionController(IMiningConcessionService miniconcService)
        {
            _miniconcService = miniconcService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MiningConcessionDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<IEnumerable<MiningConcessionDto>>>> Get()
        {
            var response = await _miniconcService.FindAllAsync();
            return TypedResults.Ok<IEnumerable<MiningConcessionDto>>(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningConcessionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MiningConcessionDto>>> Get(int id)
        {
            var response = await _miniconcService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MiningConcessionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MiningConcessionDto>>> Post([FromBody] MiningConcessionSaveDto miningConcSaveDto)
        {
            var response = await _miniconcService.CreateAsync(miningConcSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningConcessionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, Ok<MiningConcessionDto>>> Put(int id, [FromBody] MiningConcessionSaveDto miningConcSaveDto)
        {
            var response = await _miniconcService.EditAsync(id, miningConcSaveDto);
            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningConcessionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, Ok<MiningConcessionDto>>> Delete(int id)
        {
            var response = await _miniconcService.DisabledAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
