using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using real_estate.Models;

namespace real_estate.Controllers
{
    [Authorize(Roles ="Admin")]
    public class EmployeeController : Controller
    {
        real_estateDB db;
        public EmployeeController(real_estateDB _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var employee = db.Employees.ToList();
            return View(employee);
        }
        public IActionResult Details(int id)
        {
            var employee = db.Employees
                        .Include(emp => emp.properties)
                            .ThenInclude(p => p.city)
                        .Include(emp => emp.properties)
                            .ThenInclude(p => p.propertyStatus)
                        .Include(emp => emp.properties)
                            .ThenInclude(p => p.propertyType)
                        .Include(emp => emp.properties)
                            .ThenInclude(p => p.contract)
                        .FirstOrDefault(emp => emp.Id == id);


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
                db.Employees.Add(emp);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int id)
        {
            var employee = db.Employees.SingleOrDefault(emp => emp.Id == id);
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

            db.Employees.Update(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            var emp = db.Employees.FirstOrDefault(x => x.Id == id);

            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
