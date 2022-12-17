using BTL_DoAn.Application.Catalog.Categories;
using BTL_DoAn.Application.Catalog.Categories.Dtos;
using BTL_DoAn.Data.EF;
using Microsoft.AspNetCore.Mvc;

namespace BTL_DoAn.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BTL_DoAnDbContext _context;
        private readonly IManageCategory _manageCategory;

        public CategoriesController(BTL_DoAnDbContext context, IManageCategory manageCategory)
        {
            _context = context;
            _manageCategory = manageCategory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _manageCategory.GetAllCategory();
            return Ok(categories);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetCategoryRequest request)
        {
            var categories = await _manageCategory.GetAlllPaging(request);
            return Ok(categories);
        }

        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetbyId(int CategoryId)
        {
            var category = await _manageCategory.GetById(CategoryId);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }

        [HttpPost("add_category")]
        public async Task<IActionResult> Create(CreateCategoryRequest request)
        {
            var result = await _manageCategory.Create(request);
            if (result == 0)
                return BadRequest("Lỗi gì đó rồi");
            var category = await _manageCategory.GetById(result);
            return Created(nameof(GetbyId), category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryRequest request)
        {
            var Result = await _manageCategory.Update(request);
            if (Result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{CategoryId}")]
        public async Task<IActionResult> Delete(int CategoryId)
        {
            var Result = await _manageCategory.Delete(CategoryId);
            if (Result == 0)
                return BadRequest();

            return Ok();
        }
    }
}