using API.DTOs.User.Authentication;
using API.Services.Interfaces;
using Common.Constant;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AccountsController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _usersService.LoginUserAsync(request);

                if (response == null)
                {
                    return BadRequest(ErrorMessages.LoginFailed);
                }

                return Ok(response);
            }
            catch 
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}
