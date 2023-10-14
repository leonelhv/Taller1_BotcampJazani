using Jazani.Api.Exceptions;
using Jazani.Application.Admins.Dtos.Userjwts;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserjwtController : ControllerBase
    {

        private readonly IUserjwtService _userjwtService;

        public UserjwtController(IUserjwtService userjwtService)
        {
            _userjwtService = userjwtService;
        }




        [HttpPost]
        public async Task<Results<BadRequest, CreatedAtRoute<UserjwtDto>>> Post([FromBody] UserjwtSaveDto userSave)
        {
            UserjwtDto user = await _userjwtService.CreateAsync(userSave);
            return TypedResults.CreatedAtRoute(user);
        }


        // POST api/values
        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserSecurityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<BadRequest, Ok<UserSecurityDto>>> Post([FromBody] UserAuthDto userAuth)
        {
            UserSecurityDto userSecurity = await _userjwtService.LoginAsync(userAuth);

            return TypedResults.Ok(userSecurity);
        }
    }

}

