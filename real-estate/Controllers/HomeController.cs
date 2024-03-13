using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using real_estate.Models;
using real_estate.Repos.PropertyRepo;

namespace real_estate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPropertyRepo propertyRepo;

        public HomeController(ILogger<HomeController> logger,IPropertyRepo _propertyRepo)
        {
            _logger = logger;
            propertyRepo = _propertyRepo;
        }

        public IActionResult Index()
        {
            ViewData["Cities"] = propertyRepo.GetCities();
            ViewData["Status"] = propertyRepo.GetPropertyStatus();
            ViewData["Types"] = propertyRepo.GetPropertyType();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Filter(int cityId, int statusId,int typeId)
        {
            var filterList = propertyRepo.Filter(cityId, statusId, typeId);

            return Json(filterList);
        }

        public IActionResult CheckUserRole()
        {
            bool isAdminOrEmployee = User.IsInRole("Admin") || User.IsInRole("Employee");
            return Json(new { isAdminOrEmployee });
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
