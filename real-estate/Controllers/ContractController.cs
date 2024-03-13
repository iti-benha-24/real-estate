using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using real_estate.Models;
using real_estate.Repos.ContractRepo;
using real_estate.Repos.EmployeeRepo;
using real_estate.Repos.PropertyRepo;
using real_estate.ViewModels;
using System.Diagnostics.Contracts;
using Contract = real_estate.Models.Contract;

namespace real_estate.Controllers
{
    [Authorize(Roles ="Employee,Admin")]
    public class ContractController : Controller
    {
        private readonly IContractRepo contractRepo;
        private readonly PropertyRepo propertyRepo;
        private readonly EmployeeRepo employeeRepo;

        public ContractController(IContractRepo _contractRepo , PropertyRepo _propertyRepo,EmployeeRepo _employeeRepo)
        {
            contractRepo = _contractRepo;
            propertyRepo = _propertyRepo;
            employeeRepo = _employeeRepo;
        }
        public IActionResult Index()
        {
            var contracts = contractRepo.GetAll();
            return View(contracts);
        }


        public IActionResult New()
        {
            ViewData["Properties"] = propertyRepo.GetPropertiesNotHaveContract();
            ViewData["Employees"] = employeeRepo.GetAll();
            ViewData["Clients"] =   contractRepo.GetAllClients();
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
                contractRepo.Add(contract);
                contractRepo.Save();
                var prop = propertyRepo.GetById(contractVM.PropertyId);
                           //db.Properties.Where(x => x.Id == contractVM.PropertyId).FirstOrDefault();
                prop.ContractId = contract.Id;
                contractRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Properties"] =  propertyRepo.GetPropertiesNotHaveContract();
                ViewData["Employees"] =  employeeRepo.GetAll();
                ViewData["Clients"] =   contractRepo.GetAllClients();
                return View("New");
            }


        }

        public IActionResult Edit(int id)
        {
            var propertiesNotHaveContract = propertyRepo.GetPropertiesNotHaveContract();
            var contrac = contractRepo.GetById(id);
            var propertyEdit = propertyRepo.GetById((int)contrac.propertyId);
            propertiesNotHaveContract.Add(propertyEdit);
            

            ViewData["Properties"] = propertiesNotHaveContract;
            ViewData["Employees"] = employeeRepo.GetAll();
            ViewData["Clients"] = contractRepo.GetAllClients();
            var contract = contractRepo.GetById(id);
            return View("New", contract);
        }

        [HttpPost]
        public IActionResult Edit(ContractViewModel contractVM)
        {
            var contract2 = contractRepo.GetById(contractVM.Id);
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

                contractRepo.Edit(contract);
                contractRepo.Save();
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
                ViewData["Properties"] =  propertyRepo.GetPropertiesNotHaveContract();
                ViewData["Employees"] =  employeeRepo.GetAll();
                ViewData["Clients"] = contractRepo.GetAllClients();

                return View("New", contract);
            }

        }

        public IActionResult Details(int id)
        {
            var contract = contractRepo.GetById(id);
            return View(contract);

        }
        public IActionResult Delete(int id)
        {
            var contract = contractRepo.GetById(id);

            contractRepo.Delete(contract);
            contractRepo.Save();
            return RedirectToAction("Index");


        }
    }
}
