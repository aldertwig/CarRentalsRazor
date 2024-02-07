using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalsRazor.Migrations
{
    /// <inheritdoc />
    public partial class insertAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Email", "Password" },
                values: new object[,]
                {
                    { "admin@carrentals", "pass" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
