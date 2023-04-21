using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingApp.Migrations
{
    public partial class roleseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7afd359-6836-42c6-b919-6d0b77b6d76f", "15cf3369-ed56-4dd8-bdb0-fa892af21000", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c60c4e9e-d0f2-4946-a094-3838587ee415", "2aecd8e6-2faa-4c60-ac5d-01b633a93740", "Admin", "ADMIN" });
        }

       
    }
}
