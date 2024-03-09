using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using real_estate.Models;

namespace real_estate.Controllers
{
    public class EmployeeController : Controller
    {
        real_estateDB db;
        public EmployeeController()
        {
            db = new real_estateDB();
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
            if (emp!= null)
            {
                db.Employees.Add(emp);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
