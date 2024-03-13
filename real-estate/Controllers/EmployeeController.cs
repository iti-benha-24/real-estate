using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using real_estate.Models;
using real_estate.Repos.EmployeeRepo;

namespace real_estate.Controllers
{
    [Authorize(Roles ="Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeController(IEmployeeRepo _employeeRepo)
        {
            employeeRepo = _employeeRepo;
        }
        public IActionResult Index()
        {
            var employee = employeeRepo.GetAll();
            return View(employee);
        }
        public IActionResult Details(int id)
        {
            var employee = employeeRepo.GetByIdWithDetails(id);


            return View(employee);
        }
        public IActionResult Add()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Add(Employee emp)
        {
            if (emp != null)
            {
                employeeRepo.Add(emp);
                employeeRepo.Save();

                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int id)
        {
            var employee = employeeRepo.GetById(id);
            /*Include(emp => emp.properties)
                .ThenInclude(p => p.city)
            .Include(emp => emp.properties)
                .ThenInclude(p => p.propertyStatus)
            .Include(emp => emp.properties)
                .ThenInclude(p => p.propertyType)
            .Include(emp => emp.properties)
                .ThenInclude(p => p.contract)*/


            return View(employee);

        }
        [HttpPost]
        public IActionResult Edit(int id, Employee emp)
        {

            employeeRepo.Edit(emp);
            employeeRepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            var emp = employeeRepo.GetById(id);

            employeeRepo.Delete(emp);
            employeeRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
