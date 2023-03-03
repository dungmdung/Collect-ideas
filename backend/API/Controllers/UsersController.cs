using API.DTOs.GetUser;
using API.DTOs.UpdateUser;
using API.DTOs.User.CreateUser;
using API.Queries;
using API.Services.Interfaces;
using Common.Constant;
using Common.DataType;
using Common.Enums;
using Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> Create([FromBody] CreateUserRequest request)
        {
            try
            {
                var response = await _usersService.CreateUserAsync(request);

                if (response == null)
                {
                    return BadRequest(ErrorMessages.CreateError);
                }

                return Ok(request);
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> Update([FromBody] UpdateUserRequest request)
        {
            try
            {
                var response = await _usersService.UpdateUserAsync(request);

                if (response == null)
                {
                    return BadRequest(ErrorMessages.UpdateError);
                }

                return Ok(request);
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _usersService.DeleteUserAsync(id);

                if (result == false)
                {
                    return BadRequest(ErrorMessages.DeleteError);
                }

                return NoContent();
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<GetUserResponse>> GetAll()
        {
            try
            {
                var result = await _usersService.GetAllAsync();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<GetUserResponse>> GetById(int id)
        {
            try
            {
                var result = await _usersService.GetByIdAsync(id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        [HttpGet("pagedlist")]
        //[Authorize(Roles = UserRoles.Admin)]
        [AllowAnonymous]
        public async Task<ActionResult<IPagedList<GetUserResponse>>> GetPagedList([FromQuery] PagingQuery pagingQuery,
                                                                                    [FromQuery] FilterQuery filterQuery,
                                                                                    [FromQuery] SearchQuery searchQuery,
                                                                                    [FromQuery] SortQuery sortQuery)
        {
            try
            {
                var result = await _usersService.GetPagedListAsync(pagingQuery, sortQuery, searchQuery, filterQuery);

                return Ok(result.ToObject());
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}
