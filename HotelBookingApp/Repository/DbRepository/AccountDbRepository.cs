using HotelBookingApp.Models;
using HotelBookingApp.ViewModel;
using Microsoft.AspNetCore.Identity;

using NuGet.Protocol;

namespace HotelBookingApp.Repository.DbRepository
{
    public class AccountDbRepository : IAccountRepository
    {
        private UserManager<ApplicationUser> _userManager { get; }
        // login user details 
        private SignInManager<ApplicationUser> _signInManager { get; }
        private readonly IUserService _userService;

        public AccountDbRepository(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
          
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePassViewModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
           return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);


        }
    }
}
