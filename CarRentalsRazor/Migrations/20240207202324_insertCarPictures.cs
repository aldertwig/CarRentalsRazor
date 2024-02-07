using Microsoft.EntityFrameworkCore.Migrations;
using static System.Net.WebRequestMethods;

#nullable disable

namespace CarRentalsRazor.Migrations
{
    /// <inheritdoc />
    public partial class insertCarPictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarPictures",
                columns: new[] { "CarId", "PictureUrl" },
                values: new object[,]
                {
                    { 1, "https://upload.wikimedia.org/wikipedia/commons/5/54/Vw_t3_s_sst.jpg" },
                    { 1, "https://i.pinimg.com/736x/94/4e/18/944e18a91b4f7ee1848364e654c1f418.jpg" },
                    { 2, "https://upload.wikimedia.org/wikipedia/commons/7/7b/Volvo_244DL_front_20071017.jpg" },
                    { 2, "https://i.pinimg.com/originals/1e/4e/64/1e4e64ba384bea14027d002d21e320ee.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
