using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangoFusion_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedMenuItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "images/pizza.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "images/pasta.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "images/donuts.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "iamges/fastfood.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "images/smoothie.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "images/spaghetti.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "images/chichen.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "images/burger.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://example.com/images/pizza.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://example.com/images/caesar_salad.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://example.com/images/lava_cake.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://example.com/images/grilled_salmon.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://example.com/images/mango_smoothie.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://example.com/images/spaghetti_carbonara.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "https://example.com/images/caprese_salad.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "https://example.com/images/tiramisu.jpg");
        }
    }
}
