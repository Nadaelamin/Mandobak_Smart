using Mandobak_Smart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mandobak_Smart.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // 🔹 الجداول
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<SubCategory> SubCategories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 🔹 علاقات FK
            builder.Entity<SubCategory>()
                   .HasOne(sc => sc.Category)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(sc => sc.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                   .HasOne(p => p.SubCategory)
                   .WithMany(sc => sc.Products)
                   .HasForeignKey(p => p.SubCategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 🔹 ضبط نوع العمود للسعر
            builder.Entity<Product>()
                   .Property(p => p.Price)
                   .HasColumnType("decimal(18,2)");

            builder.Entity<Cart>()
                   .HasOne(c => c.User)
                   .WithMany()
                   .HasForeignKey(c => c.UserId);

            builder.Entity<CartItem>()
                   .HasOne(ci => ci.Product)
                   .WithMany(p => p.CartItems)
                   .HasForeignKey(ci => ci.ProductId);

            builder.Entity<CartItem>()
                   .HasOne(ci => ci.Cart)
                   .WithMany(c => c.Items)
                   .HasForeignKey(ci => ci.CartId);

            // 🔹 Seeding Categories
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "منتجات الألبان", IconUrl = "icons/dairy.png", IsActive = true, SortOrder = 1 },
                new Category { Id = 2, Name = "معلبات", IconUrl = "icons/canned.png", IsActive = true, SortOrder = 2 },
                new Category { Id = 3, Name = "عصائر ومشروبات", IconUrl = "icons/drinks.png", IsActive = true, SortOrder = 3 }
            );

            // 🔹 Seeding SubCategories
            builder.Entity<SubCategory>().HasData(
                new SubCategory { Id = 1, Name = "Mirro Milk", CategoryId = 1, IsActive = true, SortOrder = 1 },
                new SubCategory { Id = 2, Name = "Rodos Cheese", CategoryId = 1, IsActive = true, SortOrder = 2 },
                new SubCategory { Id = 3, Name = "Abour Land", CategoryId = 1, IsActive = true, SortOrder = 3 },
                new SubCategory { Id = 4, Name = "Tomato Cans", CategoryId = 2, IsActive = true, SortOrder = 1 },
                new SubCategory { Id = 5, Name = "Juices", CategoryId = 3, IsActive = true, SortOrder = 1 },
                new SubCategory { Id = 6, Name = "Soft Drinks", CategoryId = 3, IsActive = true, SortOrder = 2 }
            );

            // 🔹 Seeding Products
            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Mirro Full Cream", SubCategoryId = 1, Price = 10.50m, IsActive = true, SortOrder = 1 },
                new Product { Id = 2, Name = "Mirro Low Fat", SubCategoryId = 1, Price = 11.00m, IsActive = true, SortOrder = 2 },
                new Product { Id = 3, Name = "Rodos Feta", SubCategoryId = 2, Price = 25.00m, IsActive = true, SortOrder = 1 },
                new Product { Id = 4, Name = "Rodos Gouda", SubCategoryId = 2, Price = 30.00m, IsActive = true, SortOrder = 2 },
                new Product { Id = 5, Name = "Abour Land Yogurt", SubCategoryId = 3, Price = 8.50m, IsActive = true, SortOrder = 1 },
                new Product { Id = 6, Name = "Tomato Can 400g", SubCategoryId = 4, Price = 6.00m, IsActive = true, SortOrder = 1 },
                new Product { Id = 7, Name = "Orange Juice", SubCategoryId = 5, Price = 12.50m, IsActive = true, SortOrder = 1 },
                new Product { Id = 8, Name = "Apple Juice", SubCategoryId = 5, Price = 12.00m, IsActive = true, SortOrder = 2 },
                new Product { Id = 9, Name = "Cola Drink", SubCategoryId = 6, Price = 7.00m, IsActive = true, SortOrder = 1 },
                new Product { Id = 10, Name = "Lemon Soda", SubCategoryId = 6, Price = 7.50m, IsActive = true, SortOrder = 2 }
            );

            // 🔹 Seeding Companies
            builder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Nada Group", Description = "شركة استثمار عقاري متخصصة في إدارة المشاريع", Email = "info@nadagroup.com", Phone = "01158991650", Address = "أسوان - كوم أمبو", LogoUrl = "logos/nadagroup.png", IsActive = true },
                new Company { Id = 2, Name = "Smart Tech", Description = "شركة حلول برمجية وتقنية", Email = "contact@smarttech.com", Phone = "01234567890", Address = "القاهرة - مصر", LogoUrl = "logos/smarttech.png", IsActive = true }
            );

            // 🔹 Seeding Users (قبل Carts)
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "user1",
                    UserName = "user1@example.com",
                    NormalizedUserName = "USER1@EXAMPLE.COM",
                    Email = "user1@example.com",
                    NormalizedEmail = "USER1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
                     FullName = "User One"
                },
                new ApplicationUser
                {
                    Id = "user2",
                    UserName = "user2@example.com",
                    NormalizedUserName = "USER2@EXAMPLE.COM",
                    Email = "user2@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
                     FullName = "User Two"
                }
            );

           
        }

    }
}
