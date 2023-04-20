using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingApp.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomsCategories",
                columns: new[] { "Id", "CategoryName", "Description", "Price" },
                values: new object[] { 1, "Deluxe", "Spacious and luxurious accommodation option that offers guests an elevated level of comfort and sophistication. Typically located in upscale hotels and resorts, a Deluxe Room is designed to provide guests with an exceptional level of comfort and style.", 10000.0 });

            migrationBuilder.InsertData(
                table: "RoomsCategories",
                columns: new[] { "Id", "CategoryName", "Description", "Price" },
                values: new object[] { 2, "Normal", "Generally designed to accommodate one or two guests, with basic amenities such as a comfortable bed, a clean and well-appointed bathroom, and basic furnishings. Standard Rooms may also come equipped with a small work desk, a TV, and Wi-Fi access, providing guests with everything they need for a comfortable and productive stay.", 5000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomsCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomsCategories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
