using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using real_estate.Models;
using real_estate.Repos.PropertyRepo;

namespace real_estate.Controllers
{

    public class ProperityController : Controller
    {
        private readonly IPropertyRepo propertyRepo;

        public ProperityController(IPropertyRepo _propertyRepo)
        {
            propertyRepo = _propertyRepo;
        }
        public IActionResult Index(int id=1)
        {
                var pageNumber = id;
                var pageSize = 3;
                var totalProperties = propertyRepo.GetAll().Count();
                var totalPages = (int)Math.Ceiling((double)totalProperties / pageSize);
                var Queryresult = propertyRepo.GetAll();
                var PageResult = Queryresult.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                ViewData["totalPages"] = totalPages;
                ViewData["pageNum"] = pageNumber;

                return View(PageResult);
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
