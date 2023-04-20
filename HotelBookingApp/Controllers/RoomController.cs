using HotelBookingApp.Data;
using HotelBookingApp.Models;
using HotelBookingApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Controllers
{
    public class RoomController : Controller
    {

        private readonly IRoomRepository _repo;
        HotelDbContext _db;

        public RoomController(IRoomRepository repo, HotelDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        public async Task<IActionResult> GetAllRooms()
        {
            List<Room> room = await this._repo.GetAllRoom();
            return View(room);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room room = await this._repo.GetRoomById((int)id);
            return View(room);
        }

        public IActionResult Delete(int id)
        {
            var roomlist = _repo.DeleteRoom(id);
            return RedirectToAction(controllerName: "Room", actionName: "GetAllRooms");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room newRoom)
        {

            if (ModelState.IsValid)
            {
                var book = _repo.AddRoom(newRoom);
                return RedirectToAction("GetAllRooms");
            }
            ViewData["Message"] = "Data is not valid to create the Room";
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var old = await this._repo.GetRoomById(id);
            return View(old);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Room newRoom)
        {
            await _repo.UpdateRoom(newRoom.Id, newRoom);
            return RedirectToAction("GetAllRooms");
        }
    }
}
