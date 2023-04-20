using HotelBookingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data
{
    public class HotelDbContext : IdentityDbContext<ApplicationUser>
    {
        public IConfiguration _appConfig { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=HRBMSDB; ";
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);


        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomCategory> RoomsCategories { get; set;}

        public DbSet<Booking> Bookings { get; set; }




    }
}
