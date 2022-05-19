using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBAOseno.Core.Models;
using Microsoft.AspNetCore.Identity;
using CBAOseno.Services.Interfaces;
using CBAOseno.WebApi.ViewModels;
using System.Security.Claims;
using CBAOseno.Core.Enums;

namespace CBAOseno.WebApi.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        public UserRoleController(RoleManager<ApplicationRole> roleManager,
                                    UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
                Status = role.Status

            };
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name) && role.Status == Status.Enabled)
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole ApplicationRole = new ApplicationRole
                {
                    Name = model.RoleName,
                    Status = model.Status
                };
                IdentityResult result = await roleManager.CreateAsync(ApplicationRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            var roleClaims = await roleManager.GetClaimsAsync(role);
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
               Status = role.Status,
               Claims = roleClaims.Select(c => c.Value).ToList(),
            };
            foreach(var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name) && role.Status == Status.Enabled)
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else 
            {
                role.Name = model.RoleName;
                role.Status = model.Status;
                var result = await roleManager.UpdateAsync(role);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            
                
             return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ManageRoleClaims(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            var existingRoleClaims = await roleManager.GetClaimsAsync(role);
            var model = new RoleClaimsViewModel
            {
                //Id = role.Id,
                Id = id
            };
            foreach (Claim claim in ClaimsStore.AllClaims)
            {
                RoleClaim roleClaim = new RoleClaim
                {
                    ClaimType = claim.Type
                };
                if (existingRoleClaims.Any(c => c.Type == claim.Type))
                {
                    roleClaim.IsSelected = true;
                }
               
                model.Cliams.Add(roleClaim);
            }     
            
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ManageRoleClaims(RoleClaimsViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            var claims = await roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                await roleManager.RemoveClaimAsync(role, claim);
            }
            var selectedClaims = model.Cliams.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType));
            foreach (var claim in selectedClaims)
            {
                await roleManager.AddClaimAsync(role, claim);
            }
            return RedirectToAction("Edit", new { Id = model.Id});
            /*var result = await roleManager.RemoveClaimAsync(role, (Claim)claims);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove existing role claims");
                return View(model);
            }
            result = await roleManager.AddClaimAsync(role,
                (Claim)model.Cliams.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType)));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected claims to role");
                return View(model);
            }
            return RedirectToAction("Edit", new { Id = model.Id });*/
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    Email = user.Email
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.isSelected = true;
                }
                else
                {
                    userRoleViewModel.isSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].isSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].isSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("Edit", new { Id = roleId });
                }
            }

            return RedirectToAction("Edit", new { Id = roleId });
        }
        /*private readonly IUserDao _userdao;
        public UserRoleController(IUserDao userdao)
        {
            _userdao = userdao;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _userdao.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("roleName,status")] UserRole userrole)
        {
            if (!ModelState.IsValid)
            {
                return View(userrole);
            }
            await _userdao.AddAsync(userrole);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int roleId)
        {
            var roleDetails = await _userdao.GetByIdAsync(roleId);
            //if (roleDetails == null) return View("Empty");
            return View(roleDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int roleId, [Bind("roleId,roleName,status")] UserRole newUserrole)
        {
            if (!ModelState.IsValid)
            {
                return View(newUserrole);
            }
            await _userdao.UpdateAsync(roleId, newUserrole);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int roleId)
        {
            var roleDetails = await _userdao.GetByIdAsync(roleId);
            //if (roleDetails == null) return View("Empty");
            return View(roleDetails);
        }
        public async Task<IActionResult> Delete(int roleId)
        {
            var roleDetails = await _userdao.GetByIdAsync(roleId);
            //if (roleDetails == null) return View("Empty");
            return View(roleDetails);
        }
        [HttpPost /*ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int roleId)
        {
            var roleDetails = await _userdao.GetByIdAsync(roleId);
            //if (roleDetails == null) return View("Empty");
            //return View(roleDetails);
            await _userdao.DeleteAsync(roleId);
            return RedirectToAction("Index");
        } */


    }
}
