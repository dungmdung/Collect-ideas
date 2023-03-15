using API.DTOs.Category.CreateCategory;
using API.DTOs.Category.GetCategory;
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

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.QAManager)]
        public async Task<ActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            try
            {
                var response = await _categoryService.CreateCategoryAsync(request);

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
        [Authorize(Roles = UserRoles.QAManager)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _categoryService.DeleteCategoryAsync(id);

                if (result == false)
                {
                    return BadRequest(ErrorMessages.CreateError);
                }

                return Ok(Messages.ActionSuccess);
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetCategoryResponse>> GetById(int id)
        {
            try
            {
                var result = await _categoryService.GetByIdAsync(id);

                if(result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<GetCategoryResponse>> GetAll()
        {
            try
            {
                var result = await _categoryService.GetAllAsync();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, ErrorMessages.InternalServerError);
            }
        }
    }
}
