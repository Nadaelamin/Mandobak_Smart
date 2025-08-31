using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mandobak_Smart.Migrations
{
    /// <inheritdoc />
    public partial class InitCartAndCompanyV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 14, 1, 40, 842, DateTimeKind.Local).AddTicks(4212));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 14, 1, 40, 842, DateTimeKind.Local).AddTicks(4264));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 13, 55, 37, 585, DateTimeKind.Local).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 13, 55, 37, 585, DateTimeKind.Local).AddTicks(8958));
        }
    }
}
