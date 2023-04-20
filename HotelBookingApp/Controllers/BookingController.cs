using HotelBookingApp.Data;
using HotelBookingApp.Models;
using HotelBookingApp.Repository;
using HotelBookingApp.Repository.DbRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Controllers
{
    public class BookingController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IBookingRepository _repo;
        IRoomRepository _Roomrepo;
        HotelDbContext _db;


        public BookingController(IBookingRepository repo, IRoomRepository Roomrepo, HotelDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._repo = repo;
            _Roomrepo = Roomrepo;
            _db = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> GetAllBookings()
        {
            List<Booking> booking = await this._repo.GetAllBooking();
            return View(booking);

        }

        public async Task<IActionResult> Details(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }


            Booking booking = await this._repo.GetBookingById((int)id);
            return View(booking);
        }

        public IActionResult Delete(int id)
        {
            var booklist = _repo.DeleteBooking(id);
            return RedirectToAction(controllerName: "Booking", actionName: "GetAllBookings");
        }


        [HttpGet]
        public IActionResult Create()
        {
           /* List<ApplicationUser> userlist = new List<ApplicationUser>();
            userlist = _userManager.Users.ToList();
            ViewBag.listofUser = userlist;

            List<Room> li = new List<Room>();
            li = _context.Room.ToList();
            ViewBag.listofroom = li;*/
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                var book = _repo.AddBooking(booking);
                var room = _Roomrepo.GetRoomById(booking.RoomId);

                // Update the room status to false
                var rooms = new Room { Status = room.Status.Equals(false) };
                _Roomrepo.UpdateRoom(rooms.Id, rooms);
                return RedirectToAction("GetAllBookings");
            }
            ViewData["Message"] = "Data is not valid to create the booking";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
           /* List<Room> li = new List<Room>();
            li = _context.Room.ToList();
            ViewBag.listofroom = li;

            List<ApplicationUser> userlist = new List<ApplicationUser>();
            userlist = _userManager.Users.ToList();
            ViewBag.listofUser = userlist;*/

            var old = await this._repo.GetBookingById(id);
            return View(old);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Booking booking)
        {

            await _repo.UpdateBooking(booking.Id, booking);
            return RedirectToAction("GetAllBookings");
        }

    }
}
