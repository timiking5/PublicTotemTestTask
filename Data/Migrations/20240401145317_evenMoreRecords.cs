using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class evenMoreRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExpenditureRecord",
                columns: new[] { "Id", "Amount", "CategoryId", "Date", "Description" },
                values: new object[,]
                {
                    { 8, 10000m, 1, new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Extra hungry" },
                    { 9, 8000m, 5, new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Extra hungry" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenditureRecord",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExpenditureRecord",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
