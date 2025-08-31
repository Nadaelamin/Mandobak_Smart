using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mandobak_Smart.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8de5bd4d-4e1e-4153-8b90-b068e896d7ff", "AQAAAAIAAYagAAAAEGO19BZQNBJUYWzjKco1ODWMmQHp/wkzE4vLxa7w3TZnWv/XAQwEFaQjp/1sODYW1Q==", "feb1607a-cfbb-40eb-9c67-8e815c5fcdda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c1aba25-3179-4822-bf07-901857cb9828", "AQAAAAIAAYagAAAAEI+2k7i136Jp8CgxTymbvLfsHTpHHwgdiwnAHcp9TAXzky+ToD3UVuF/a3d8mroFMw==", "90232b16-890a-4d8c-b1f5-47f54037fb08" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "665b720b-a327-47b3-be29-8acb1065445b", "AQAAAAIAAYagAAAAECAW+FC3YO4Mx1r1o85tXwsykGaBdi+GktNVo/JgbOPqeYWaXFwmiHMAae/2KdCdPw==", "0d799db3-e6c6-4bed-be29-51c832115e7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c423c698-a61e-4392-9e7f-003a09f4daa9", "AQAAAAIAAYagAAAAEFDk4p/hq6WpHR5kwu1njJCvg1fwQY9sKEVw9seTY8Ml9zO9Q6tRfLwKMpXXvxofUg==", "205a7708-260d-40d5-9ca8-d3cfdf7371ce" });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CreatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 31, 11, 19, 10, 175, DateTimeKind.Local).AddTicks(7207), "user1" },
                    { 2, new DateTime(2025, 8, 31, 11, 19, 10, 175, DateTimeKind.Local).AddTicks(7295), "user2" }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 1, 3, 1 },
                    { 3, 2, 7, 3 }
                });
        }
    }
}
