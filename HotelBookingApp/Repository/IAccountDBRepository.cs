using HotelBookingApp.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace HotelBookingApp.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> ChangePasswordAsync(ChangePassViewModel model);
    }
}
