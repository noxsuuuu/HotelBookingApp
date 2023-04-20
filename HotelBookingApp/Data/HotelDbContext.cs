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
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=HotelDB; ";
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // seed some basic data 
            // administrator user in the user table
            modelBuilder.SeedDefaultData();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomCategory> RoomsCategories { get; set;}

        public DbSet<Booking> Bookings { get; set; }




    }
}
