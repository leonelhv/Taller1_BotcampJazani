using Jazani.Application.Soc.Dtos.Holders;
using Jazani.Application.Soc.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Soc
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolderController : ControllerBase
    {

        private readonly IHolderService _holderService;
        public HolderController(IHolderService holderService)
        {
            _holderService = holderService;
        }

        // GET: api/<HolderController>
        [HttpGet]
        public async Task<IEnumerable<HolderDto>> Get()
        {
            return await _holderService.FindAllAsync();
        }

        // GET api/<HolderController>/5
        [HttpGet("{id}")]
        public async Task<HolderDto> Get(int id)
        {
            return await _holderService.FindByIdAsync(id);
        }

    }
}
