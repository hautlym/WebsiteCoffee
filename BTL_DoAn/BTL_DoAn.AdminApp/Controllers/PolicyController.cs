using BTL_DoAn.ApiIntegration.Service.PoliciesApiClient;
using BTL_DoAn.Application.Catalog.Policies.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_DoAn.AdminApp.Controllers
{
   
    public class PolicyController : BaseController
    {
        private readonly IPolicyApiClient _policyApiClient;

        public PolicyController(IPolicyApiClient policyApiClient)
        {
            _policyApiClient = policyApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int PageIndex = 1, int PageSize = 10)
        {
            var request = new GetPolicyRequest()
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                keyword =keyword,
            };

            var data = await _policyApiClient.GetAllPaging(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuscessMsg = TempData["result"];
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePolicyRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _policyApiClient.CreatePolicy(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm chính sách thành công";
                return RedirectToAction("Index");

            }
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _policyApiClient.GetById(id);
            if (result != null)
            {
                var updateRequest = new UpdatePolicyRequest()
                {
                    PolicyId = id,
                    PolicyName = result.PolicyName,
                    PolicyDescription = result.PolicyDescription,
                    Discount = result.Discount,
                    StartDate = result.StartDate,
                    EndDate = result.EndDate,
                    Voucher = result.Voucher,
                    ProductId = result.ProductId,
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdatePolicyRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _policyApiClient.UpdatePolicy(request.PolicyId, request);
            if (result)
            {
                TempData["result"] = "Cập nhật thông tin thành công";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", " Cập nhật không thành công");
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new DeletePolicyRequest()
            {
                PolicyId = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeletePolicyRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _policyApiClient.Delete(request.PolicyId);
            if (result)
            {
                TempData["result"] = "Xóa danh mục thành công";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _policyApiClient.GetById(id);
            return View(result);
        }
    }
}
