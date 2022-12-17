using BTL_DoAn.ApiIntegration.Service.ContactApiClient;
using BTL_DoAn.ApiIntegration.Service.ProductApiClient;
using BTL_DoAn.Application.Catalog.Contacts.Dtos;
using BTL_DoAn.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BTL_DoAn.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductApiClient _productApiClient;
        private readonly IContactApiClient _contactApiClient;
        public HomeController(ILogger<HomeController> logger, IProductApiClient productApiClient, IContactApiClient contactApiClient)
        {
            _logger = logger;
            _productApiClient = productApiClient;
            _contactApiClient = contactApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var Products = await _productApiClient.GetAll();
            var HomeViewModel = new HomeViewModels()
            {
                CoffeeProduct = Products.Where(x => x.CategoryId == 2).Skip(0).Take(6).ToList(),
                Drinkproduct = Products.Where(x => x.CategoryId==3).Skip(0).Take(6).ToList(),
                FastFoodProduct = Products.Where(x => x.CategoryId == 4).Skip(0).Take(6).ToList(),
            };
            return View(HomeViewModel);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(CreateContactRequest request)
        {
            var kq = await _contactApiClient.CreateContact(request);
            if (kq.IsSuccessed)
            {
                ViewBag.SuscessMsg = "Gửi thành công";
            }
            else
            {
                ViewBag.SuscessMsg = "Gửi thành công";
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}