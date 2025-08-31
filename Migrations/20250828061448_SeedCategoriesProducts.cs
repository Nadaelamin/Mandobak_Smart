using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mandobak_Smart.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoriesProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Description", "IsActive", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 1, 1, null, true, "Mirro Milk", 1 },
                    { 2, 1, null, true, "Rodos Cheese", 2 },
                    { 3, 1, null, true, "Abour Land", 3 },
                    { 4, 2, null, true, "Tomato Cans", 1 },
                    { 5, 3, null, true, "Juices", 1 },
                    { 6, 3, null, true, "Soft Drinks", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "SortOrder", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, null, null, true, "Mirro Full Cream", 10.50m, 1, 1 },
                    { 2, null, null, true, "Mirro Low Fat", 11.00m, 2, 1 },
                    { 3, null, null, true, "Rodos Feta", 25.00m, 1, 2 },
                    { 4, null, null, true, "Rodos Gouda", 30.00m, 2, 2 },
                    { 5, null, null, true, "Abour Land Yogurt", 8.50m, 1, 3 },
                    { 6, null, null, true, "Tomato Can 400g", 6.00m, 1, 4 },
                    { 7, null, null, true, "Orange Juice", 12.50m, 1, 5 },
                    { 8, null, null, true, "Apple Juice", 12.00m, 2, 5 },
                    { 9, null, null, true, "Cola Drink", 7.00m, 1, 6 },
                    { 10, null, null, true, "Lemon Soda", 7.50m, 2, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Products");
        }
    }
}
