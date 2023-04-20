using HotelBookingApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    public class RoleController : Controller
    {
        public RoleManager<IdentityRole> _roleManager { get; }

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Create()
        {

            //_roleManager.Roles;
            //_roleManager.DeleteAsync();
            //_roleManager.UpdateAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel, IdentityRole rolemodel)
        {
            if (!_roleManager.RoleExistsAsync(rolemodel.Name).GetAwaiter().GetResult())
            {

                if (ModelState.IsValid)
                {
                    //var newUser = new ApplicationUser
                    //{
                    //    Id = Guid.NewGuid(),
                    //    UserName = "username",
                    //    // Other user properties
                    //};

                    var role = new IdentityRole
                    {
                        Name = roleViewModel.Name
                    };
                    var result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("GetAllRoles");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                //popup message
            }
            //else
            //popup message
            // TempData["ErrorMessage"] = "User role already exist";
            return View(roleViewModel);
        }


        [HttpGet]
        public IActionResult GetAllRoles()
        {
            return View(_roleManager.Roles.ToList());
            //RoleViewModel role = this._roleManager.to();
            //return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string? id)
        {
            //var role = await _roleManager.FindByIdAsync(id);
            //var getroles = await _roleManager.GetRoleIdAsync(role);
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            var roleViewModel = new RoleViewModel
            {
                Name = role.Name
            };

            return View(roleViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleViewModel roleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(roleViewModel);
            }

            var existingRole = await _roleManager.FindByIdAsync(roleViewModel.Id.ToString());

            if (existingRole == null)
            {
                return NotFound();
            }

            existingRole.Name = roleViewModel.Name;
            existingRole.NormalizedName = roleViewModel.Name.ToUpperInvariant(); // Update the normalized name

            var result = await _roleManager.UpdateAsync(existingRole);

            if (!result.Succeeded)
            {
                // Handle the error
            }

            return RedirectToAction("GetAllRoles");
        }

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Find the role by ID
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            // If role is not found, return NotFound result
            if (role == null)
            {
                return NotFound();
            }

            // Convert IdentityRole to RoleViewModel
            RoleViewModel roleViewModel = new RoleViewModel
            {
                Id = Guid.Parse(role.Id),
                Name = role.Name
            };

            return View(roleViewModel);
        }
        public async Task<IActionResult> Delete(Guid Id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(Id.ToString());
            var result = await _roleManager.DeleteAsync(role);
            return RedirectToAction(controllerName: "Roles", actionName: "GetAllRoles");
        }
    }
}

