using HotelBookingApp.Models;
using HotelBookingApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    public class RoomCategoryController : Controller
    {
        private readonly IRoomCategoryRepository _repo;

        public RoomCategoryController(IRoomCategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> GetAllRoomCategory()
        {

            var catlist = await _repo.GetAllRoomCategories();
            return View(catlist);

        }

    }
}
