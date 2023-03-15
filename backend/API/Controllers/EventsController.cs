using API.DTOs.Event.CreateEvent;
using API.DTOs.Event.GetEvent;
using API.DTOs.Event.UpdateEvent;
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
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController (IEventService facultyService)
        {
            _eventService = facultyService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<GetEventResponse>> GetAll()
        {
            try
            {
                var result = await _eventService.GetAllAsync();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetEventResponse>> GetById(int id)
        {
            try
            {
                var result = await _eventService.GetByIdAsync(id);

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
        public async Task<ActionResult<CreateEventResponse>> Create([FromBody] CreateEventRequest request)
        {
            try
            {
                var response = await _eventService.CreateEventAsync(request);

                if (response == null)
                {
                    return BadRequest(ErrorMessages.CreateError);
                }

                return Ok(response);
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<UpdateEventResponse>> Update([FromBody] UpdateEventRequest request)
        {
            try
            {
                var response = await _eventService.UpdateEventAsync(request);

                if (response == null)
                {
                    return BadRequest(ErrorMessages.CreateError);
                }

                return Ok(response);
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
                var result = await _eventService.DeleteEventAsync(id);

                if (result == false)
                {
                    return BadRequest(ErrorMessages.DeleteError);
                }

                return Ok(Messages.ActionSuccess);
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}
