using API.DTOs.Thumbs.Thumb;
using API.Services.Interfaces;
using Common.Constant;
using Common.DataType;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ThumbsController : ControllerBase
    {
        private readonly IThumbsService _thumbServices;

        public ThumbsController(IThumbsService thumbservices)
        {
            _thumbServices = thumbservices;
        }

        [HttpPost]
        public async Task<ActionResult<Response<ThumbResponse>>> Create([FromBody] ThumbRequest request)
        {
            try
            {
                var response = await _thumbServices.CreateThumbAsync(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(response);
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
