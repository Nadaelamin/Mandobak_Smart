using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mandobak_Smart.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersBeforeCarts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user1", 0, "665b720b-a327-47b3-be29-8acb1065445b", "user1@example.com", true, "User One", false, null, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", "AQAAAAIAAYagAAAAECAW+FC3YO4Mx1r1o85tXwsykGaBdi+GktNVo/JgbOPqeYWaXFwmiHMAae/2KdCdPw==", null, false, "0d799db3-e6c6-4bed-be29-51c832115e7c", false, "user1@example.com" },
                    { "user2", 0, "c423c698-a61e-4392-9e7f-003a09f4daa9", "user2@example.com", true, "User Two", false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFDk4p/hq6WpHR5kwu1njJCvg1fwQY9sKEVw9seTY8Ml9zO9Q6tRfLwKMpXXvxofUg==", null, false, "205a7708-260d-40d5-9ca8-d3cfdf7371ce", false, "user2@example.com" }
                });

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 11, 19, 10, 175, DateTimeKind.Local).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 11, 19, 10, 175, DateTimeKind.Local).AddTicks(7295));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2");

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 10, 39, 29, 706, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 31, 10, 39, 29, 707, DateTimeKind.Local).AddTicks(135));
        }
    }
}
