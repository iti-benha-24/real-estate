using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using real_estate.Models;

namespace real_estate.Controllers
{
    public class Employee : Controller
    {
        real_estateDB db;
        public Employee()
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

        //public IActionResult Add(Employee employee)
        //{
        //    if(ModelState.IsValid)
        //    db.Employees.Add(employee);
        //    db.SaveChanges();

        //    return View();

        //}
    }
}
