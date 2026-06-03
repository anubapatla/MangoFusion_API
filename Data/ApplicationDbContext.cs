using MangoFusion_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MangoFusion_API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    Id = 1,
                    Name = "Pizza",
                    Description = "Delicious cheese pizza with tomato sauce and fresh basil.",
                    Category = "Main Course",
                    SpecialTag = "Vegetarian",
                    Price = 9.99,
                    Image = "images/pizza.jpg"
                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Caesar Salad",
                    Description = "Crisp romaine lettuce with Caesar dressing, croutons, and Parmesan cheese.",
                    Category = "Appetizer",
                    SpecialTag = "Gluten-Free",
                    Price = 6.99,
                    Image = "images/pasta.jpg"
                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Chocolate Lava Cake",
                    Description = "Warm chocolate cake with a gooey molten center, served with vanilla ice cream.",
                    Category = "Dessert",
                    SpecialTag = "Vegetarian",
                    Price = 5.99,
                    Image = "images/donuts.jpg"
                },
                new MenuItem
                {
                    Id = 4,
                    Name = "Grilled Salmon",
                    Description = "Fresh salmon fillet grilled to perfection, served with lemon butter sauce.",
                    Category = "Main Course",
                    SpecialTag = "Gluten-Free",
                    Price = 14.99,
                    Image = "iamges/fastfood.jpg"
                },
                new MenuItem
                {
                    Id = 5,
                    Name = "Mango Smoothie",
                    Description = "Refreshing mango smoothie made with fresh mangoes and yogurt.",
                    Category = "Beverage",
                    SpecialTag = "Vegan",
                    Price = 4.99,
                    Image = "images/smoothie.jpg"
                },
                new MenuItem
                {
                    Id = 6,
                    Name = "Spaghetti Carbonara",
                    Description = "Classic Italian pasta dish with creamy sauce, pancetta, and Parmesan cheese.",
                    Category = "Main Course",
                    SpecialTag = "Contains Pork",
                    Price = 11.99,
                    Image = "images/spaghetti.jpg"
                },
                new MenuItem
                {
                    Id = 7,
                    Name = "Caprese Salad",
                    Description = "Fresh mozzarella, ripe tomatoes, and basil drizzled with balsamic glaze.",
                    Category = "Appetizer",
                    SpecialTag = "Vegetarian",
                    Price = 7.99,
                    Image = "images/chichen.jpg"
                },
                new MenuItem
                {
                    Id = 8,
                    Name = "Tiramisu",
                    Description = "Classic Italian dessert with layers of coffee-soaked ladyfingers and mascarpone cream.",
                    Category = "Dessert",
                    SpecialTag = "Vegetarian",
                    Price = 6.99,
                    Image = "images/burger.jpg"
                }

            );
        }
    }
}
