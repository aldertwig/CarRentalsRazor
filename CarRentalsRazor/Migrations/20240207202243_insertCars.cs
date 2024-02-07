using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalsRazor.Migrations
{
    /// <inheritdoc />
    public partial class insertCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Brand", "Model", "Capacity", "RentPerDay", "Available" },
                values: new object[,]
                {
                    { "Volkswagen", "T3", "8", "550", true },
                    { "Volvo", "244DL", "5", "300", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
