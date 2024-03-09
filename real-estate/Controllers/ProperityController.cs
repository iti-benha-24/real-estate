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
        public ProperityController()
        {
           propertyRepo = new PropertyRepo();
        }
        public IActionResult Index()
        {
            return View(propertyRepo.GetAll());
        }
        public IActionResult Create()
        {
            ALLViewData();
            return View();
        }

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
        public IActionResult Edit(int id)
        {
            ALLViewData();
            return View("Create", propertyRepo.GetDetails(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Property property)
        {
            ALLViewData();
            /*            var prop = CON.Properties
                            .Include(p => p.employee)
                            .Include(p => p.city)
                            .Include(p => p.propertyStatus)
                            .Include(p => p.propertyType)
                            .SingleOrDefault(p => p.Id == id);
            prop.Id = property.Id;
            prop.PropertyImg = property.PropertyImg;
            prop.Address = property.Address;
            prop.Price = property.Price;
            prop.city = property.city;
            prop.cityId = property.cityId;
            prop.PropertyTypeId = property.PropertyTypeId;
            prop.PropertySize = property.PropertySize;
            prop.NumBedrooms = property.NumBedrooms;
            prop.NumBathrooms = property.NumBathrooms;
            prop.Features = property.Features;
            prop.EmployeeId = property.EmployeeId;
            prop.PropertyStatusId = property.PropertyStatusId;
            prop.ContractId= property.ContractId;*/

            propertyRepo.Update(property);
            propertyRepo.SaveChanges();

            return RedirectToAction("Index");
        }
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
