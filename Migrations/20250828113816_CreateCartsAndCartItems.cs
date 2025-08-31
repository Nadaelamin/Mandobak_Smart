using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandobak_Smart.Migrations
{
    /// <inheritdoc />
    public partial class CreateCartsAndCartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 14, 38, 15, 33, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 14, 38, 15, 33, DateTimeKind.Local).AddTicks(9475));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 14, 26, 10, 519, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 14, 26, 10, 519, DateTimeKind.Local).AddTicks(5013));
        }
    }
}
