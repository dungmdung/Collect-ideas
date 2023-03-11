using API.DTOs.Faculty.CreateFaculty;
using API.DTOs.Faculty.GetFaculty;
using API.DTOs.Faculty.UpdateFaculty;
using API.Services.Interfaces;
using Common.Constant;
using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultiesController (IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<GetFacultyResponse>> GetAll()
        {
            try
            {
                var result = await _facultyService.GetAllAsync();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetFacultyResponse>> GetById(int id)
        {
            try
            {
                var result = await _facultyService.GetByIdAsync(id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<CreateFacultyResponse>> Create([FromBody] CreateFacultyRequest request)
        {
            try
            {
                var response = await _facultyService.CreateFacultyAsync(request);

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
        public async Task<ActionResult<UpdateFacultyResponse>> Update([FromBody] UpdateFacultyRequest request)
        {
            try
            {
                var response = await _facultyService.UpdateFacultyAsync(request);

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

        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _facultyService.DeleteUserAsync(id);

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
    }
}
