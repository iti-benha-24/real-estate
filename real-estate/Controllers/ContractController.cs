using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using real_estate.Models;
using real_estate.ViewModels;
using System.Diagnostics.Contracts;
using Contract = real_estate.Models.Contract;

namespace real_estate.Controllers
{
    [Authorize(Roles ="Employee,Admin")]
    public class ContractController : Controller
    {
        real_estateDB db;
        public ContractController(real_estateDB _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var contracts = db.Contracts.Include(x => x.property).ThenInclude(x=>x.propertyStatus).Include(x => x.employee).Include(x => x.client).ToList();
            return View(contracts);
        }


        public IActionResult New()
        {
            ViewData["Properties"] = db.Properties.Where(x => x.contract == null).ToList();
            ViewData["Employees"] = db.Employees.ToList();
            ViewData["Clients"] = db.Clients.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult New(ContractViewModel contractVM)
        {
            if (ModelState.IsValid)
            {
                Contract contract = new Contract()
                {
                    propertyId = contractVM.PropertyId,
                    employeeId = contractVM.EmployeeId,
                    clientId = contractVM.ClientId,
                    StartDate = contractVM.StartDate,
                    EndDate = contractVM.EndDate
                };
                db.Contracts.Add(contract);
                db.SaveChanges();
                var prop = db.Properties.Where(x => x.Id == contractVM.PropertyId).FirstOrDefault();
                prop.ContractId = contract.Id;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Properties"] = db.Properties.Where(x => x.contract == null).ToList();
                ViewData["Employees"] = db.Employees.ToList();
                ViewData["Clients"] = db.Clients.ToList();
                return View("New");
            }


        }

        public IActionResult Edit(int id)
        {
            var propertiesNotHaveContract= db.Properties.Where(x => x.contract == null).ToList();
            var contrac = db.Contracts.Include(x=>x.property).Include(c=>c.employee).Include(x=>x.employee).FirstOrDefault(x => x.Id == id);
            var propertyEdit = db.Properties.Where(x => x.Id == contrac.propertyId).FirstOrDefault();
            propertiesNotHaveContract.Add(propertyEdit);
            

            ViewData["Properties"] = propertiesNotHaveContract;
            ViewData["Employees"] = db.Employees.ToList();
            ViewData["Clients"] = db.Clients.ToList();
            var contract = db.Contracts.Include(x=>x.property).Include(x=>x.client).Include(x=>x.employee).SingleOrDefault(x => x.Id == id);
            return View("New", contract);
        }

        [HttpPost]
        public IActionResult Edit(ContractViewModel contractVM)
        {
            var contract2 = db.Contracts.Include(x => x.property).Include(x => x.client).Include(x => x.employee).SingleOrDefault(x => x.Id == contractVM.Id);
            if (ModelState.IsValid)
            {
                Contract contract = new Contract()
                {
                   // Id = contractVM.Id,
                    propertyId = contract2.propertyId,
                    employeeId = contract2.employeeId,
                    clientId = contract2.clientId,
                    StartDate = contractVM.StartDate,
                    EndDate = contractVM.EndDate
                };

                db.Contracts.Update(contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Contract contract = new Contract()
                {
                    Id=contractVM.Id,
                    propertyId = contractVM.PropertyId,
                    employeeId = contractVM.EmployeeId,
                    clientId = contractVM.ClientId,
                    StartDate = contractVM.StartDate,
                    EndDate = contractVM.EndDate
                };
                ViewData["Properties"] = db.Properties.ToList();
                ViewData["Employees"] = db.Employees.ToList();
                ViewData["Clients"] = db.Clients.ToList();

                return View("New", contract);
            }

        }

        public IActionResult Details(int id)
        {
            var contract = db.Contracts.Include(x => x.property).ThenInclude(x=>x.city).Include(x => x.employee).Include(x => x.client).FirstOrDefault(x => x.Id == id);
            return View(contract);

        }
        public IActionResult Delete(int id)
        {
            var contract = db.Contracts.FirstOrDefault(x => x.Id == id);

            db.Contracts.Remove(contract);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
