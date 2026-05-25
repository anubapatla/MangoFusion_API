using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MangoFusion_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedMenuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 1, "Main Course", "Delicious cheese pizza with tomato sauce and fresh basil.", "https://example.com/images/pizza.jpg", "Pizza", 9.9900000000000002, "Vegetarian" },
                    { 2, "Appetizer", "Crisp romaine lettuce with Caesar dressing, croutons, and Parmesan cheese.", "https://example.com/images/caesar_salad.jpg", "Caesar Salad", 6.9900000000000002, "Gluten-Free" },
                    { 3, "Dessert", "Warm chocolate cake with a gooey molten center, served with vanilla ice cream.", "https://example.com/images/lava_cake.jpg", "Chocolate Lava Cake", 5.9900000000000002, "Vegetarian" },
                    { 4, "Main Course", "Fresh salmon fillet grilled to perfection, served with lemon butter sauce.", "https://example.com/images/grilled_salmon.jpg", "Grilled Salmon", 14.99, "Gluten-Free" },
                    { 5, "Beverage", "Refreshing mango smoothie made with fresh mangoes and yogurt.", "https://example.com/images/mango_smoothie.jpg", "Mango Smoothie", 4.9900000000000002, "Vegan" },
                    { 6, "Main Course", "Classic Italian pasta dish with creamy sauce, pancetta, and Parmesan cheese.", "https://example.com/images/spaghetti_carbonara.jpg", "Spaghetti Carbonara", 11.99, "Contains Pork" },
                    { 7, "Appetizer", "Fresh mozzarella, ripe tomatoes, and basil drizzled with balsamic glaze.", "https://example.com/images/caprese_salad.jpg", "Caprese Salad", 7.9900000000000002, "Vegetarian" },
                    { 8, "Dessert", "Classic Italian dessert with layers of coffee-soaked ladyfingers and mascarpone cream.", "https://example.com/images/tiramisu.jpg", "Tiramisu", 6.9900000000000002, "Vegetarian" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
