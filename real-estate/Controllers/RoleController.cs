using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using real_estate.Models;
using real_estate.ViewModels;

namespace real_estate.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }
        public IActionResult AddRole( )
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleVM)
        {
            if(ModelState.IsValid)
            {
                IdentityRole roleModel = new IdentityRole()
                {
                    Name = roleVM.RoleName
                };

              IdentityResult result= await roleManager.CreateAsync(roleModel);
              
             
                
            }
            return View("AddRole");
        }
    }
}
