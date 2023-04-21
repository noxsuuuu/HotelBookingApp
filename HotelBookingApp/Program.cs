using HotelBookingApp.Data;
using HotelBookingApp.Models;
using HotelBookingApp.Repository;
using HotelBookingApp.Repository.DbRepository;
using HotelBookingApp.Service;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<HotelDbContext>();
builder.Services.AddScoped<HotelDbContext, HotelDbContext>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountRepository, AccountDbRepository>();
builder.Services.AddScoped<IBookingRepository, BookingDbRepository>();
builder.Services.AddScoped<IRoomRepository, RoomDbRepository>();
builder.Services.AddScoped<IRoomCategoryRepository, RoomCategoryDbRepository>();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<HotelDbContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
