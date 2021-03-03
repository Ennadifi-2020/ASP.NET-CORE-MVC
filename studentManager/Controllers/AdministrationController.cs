using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using studentManager.Areas.Identity.Data;
using studentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace studentManager.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                         UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task  <IActionResult> CreateRole(Role role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                   Name = role.RoleName  
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");    
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
            }
            
            return View(role);
        }
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);

        }

        /*[HttpGet]
        public async Task <IActionResult> EditRole(string id)
        {
            
        }*/
        
    }

    internal class UserManager
    {
        public static IEnumerable<object> Users { get; internal set; }

        internal static Task<bool> IsInRoleAsync(object user, string name)
        {
            throw new NotImplementedException();
        }
    }

    public class ApplicationUser
    {
    }
}
