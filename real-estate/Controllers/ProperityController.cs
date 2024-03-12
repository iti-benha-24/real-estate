using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using real_estate.Models;
using real_estate.Repos;

namespace real_estate.Controllers
{
    
    public class ProperityController : Controller
    {
        PropertyRepo propertyRepo;
        public ProperityController(PropertyRepo _propertyRepo)
        {
           propertyRepo= _propertyRepo;
        }
        public IActionResult Index()
        {
            return View(propertyRepo.GetAll());
        }

        [Authorize(Roles ="Employee,Admin")]       
        public IActionResult Create()
        {
            ALLViewData();
            return View();
        }
        [Authorize(Roles = "Employee,Admin")]
        [HttpPost]
        public IActionResult Create(Property property)
        {
            ALLViewData();

            propertyRepo.Add(property);
            propertyRepo.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            ALLViewData();
            return View(propertyRepo.GetDetails(id));
        }
        [Authorize(Roles = "Employee,Admin")]
        public IActionResult Edit(int id)
        {
            ALLViewData();
            return View("Create", propertyRepo.GetDetails(id));
        }
        [Authorize(Roles = "Employee,Admin")]
        [HttpPost]
        public IActionResult Edit(int id, Property property)
        {
            ALLViewData();
            propertyRepo.Update(property);
            propertyRepo.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Employee,Admin")]
        public IActionResult Delete(int id)
        {
            Property property = propertyRepo.GetById(id);

            propertyRepo.Delete(id);
            propertyRepo.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        private void ALLViewData()
        {
            ViewData["Employees"] = propertyRepo.GetAllEmp();
            ViewData["Cities"] = propertyRepo.GetCities();
            ViewData["Status"] = propertyRepo.GetPropertyStatus();
            ViewData["Types"] = propertyRepo.GetPropertyType();
        }
    }
}
