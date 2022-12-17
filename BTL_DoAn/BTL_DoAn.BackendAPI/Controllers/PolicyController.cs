using BTL_DoAn.Application.Catalog.Policies;
using BTL_DoAn.Application.Catalog.Policies.Dtos;
using BTL_DoAn.Data.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_DoAn.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly BTL_DoAnDbContext _context;
        private readonly IManagePolicy _managePolicy;

        public PolicyController(BTL_DoAnDbContext context, IManagePolicy managePolicy)
        {
            _context = context;
            _managePolicy = managePolicy;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _managePolicy.GetAllPolicy();
            return Ok(categories);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetPolicyRequest request)
        {
            var categories = await _managePolicy.GetAlllPaging(request);
            return Ok(categories);
        }

        [HttpGet("{PolicyId}")]
        public async Task<IActionResult> GetbyId(int PolicyId)
        {
            var category = await _managePolicy.GetById(PolicyId);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Create(CreatePolicyRequest request)
        {
            var result = await _managePolicy.Create(request);
            if (result == 0)
                return BadRequest("Lỗi gì đó rồi");
            var category = await _managePolicy.GetById(result);
            return Created(nameof(GetbyId), category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePolicyRequest request)
        {
            var Result = await _managePolicy.Update(request);
            if (Result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{policyId}")]
        public async Task<IActionResult> Delete(int policyId)
        {
            var Result = await _managePolicy.Delete(policyId);
            if (Result == 0)
                return BadRequest();

            return Ok();
        }
    }
}
