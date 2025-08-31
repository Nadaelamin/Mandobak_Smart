using Mandobak_Smart.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mandobak_Smart.Data
{
    public static class DbInitializer
    {
        // 🔹 Seed Users
        public static async Task SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user1 = new ApplicationUser
                {
                    UserName = "Nada",
                    Email = "nada@example.com",
                    FullName = "Nada Magdy",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user1, "Nada@123");

                var user2 = new ApplicationUser
                {
                    UserName = "Ahmed",
                    Email = "ahmed@example.com",
                    FullName = "Ahmed Ali",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user2, "Ahmed@123");
            }
        }

        // 🔹 Seed Categories, SubCategories, Products
        public static void SeedCategories(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                var dairy = new Category { Id = 1, Name = "منتجات الألبان", IconUrl = "icons/dairy.png", IsActive = true, SortOrder = 1 };
                var canned = new Category { Id = 2, Name = "معلبات", IconUrl = "icons/canned.png", IsActive = true, SortOrder = 2 };
                var drinks = new Category { Id = 3, Name = "عصائر ومشروبات", IconUrl = "icons/drinks.png", IsActive = true, SortOrder = 3 };

                context.Categories.AddRange(dairy, canned, drinks);
                context.SubCategories.AddRange(
                    new SubCategory { Id = 1, Name = "Mirro Milk", CategoryId = 1 },
                    new SubCategory { Id = 2, Name = "Rodos Cheese", CategoryId = 1 },
                    new SubCategory { Id = 3, Name = "Abour Land", CategoryId = 1 },
                    new SubCategory { Id = 4, Name = "Tomato Cans", CategoryId = 2 },
                    new SubCategory { Id = 5, Name = "Juices", CategoryId = 3 },
                    new SubCategory { Id = 6, Name = "Soft Drinks", CategoryId = 3 }
                );

                context.Products.AddRange(
                    new Product { Id = 1, Name = "Mirro Full Cream", SubCategoryId = 1, Price = 10.50m },
                    new Product { Id = 2, Name = "Mirro Low Fat", SubCategoryId = 1, Price = 11.00m },
                    new Product { Id = 3, Name = "Rodos Feta", SubCategoryId = 2, Price = 25.00m },
                    new Product { Id = 4, Name = "Rodos Gouda", SubCategoryId = 2, Price = 30.00m },
                    new Product { Id = 5, Name = "Abour Land Yogurt", SubCategoryId = 3, Price = 8.50m },
                    new Product { Id = 6, Name = "Tomato Can 400g", SubCategoryId = 4, Price = 6.00m },
                    new Product { Id = 7, Name = "Orange Juice", SubCategoryId = 5, Price = 12.50m },
                    new Product { Id = 8, Name = "Apple Juice", SubCategoryId = 5, Price = 12.00m },
                    new Product { Id = 9, Name = "Cola Drink", SubCategoryId = 6, Price = 7.00m },
                    new Product { Id = 10, Name = "Lemon Soda", SubCategoryId = 6, Price = 7.50m }
                );

                context.SaveChanges();
            }
        }

        // 🔹 Seed Companies
        public static void SeedCompanies(AppDbContext context)
        {
            if (!context.Companies.Any())
            {
                context.Companies.AddRange(
                    new Company { Id = 1, Name = "Nada Group", Description = "شركة استثمار عقاري", Email = "info@nadagroup.com", Phone = "01158991650", Address = "أسوان - كوم أمبو", LogoUrl = "logos/nadagroup.png", IsActive = true },
                    new Company { Id = 2, Name = "Smart Tech", Description = "شركة حلول برمجية", Email = "contact@smarttech.com", Phone = "01234567890", Address = "القاهرة - مصر", LogoUrl = "logos/smarttech.png", IsActive = true }
                );
                context.SaveChanges();
            }
        }

        
        
    }
}
