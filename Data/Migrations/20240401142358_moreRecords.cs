using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class moreRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ExpenditureRecord",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 4000m);

            migrationBuilder.InsertData(
                table: "ExpenditureRecord",
                columns: new[] { "Id", "Amount", "CategoryId", "Date", "Description" },
                values: new object[,]
                {
                    { 2, 3000m, 1, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some spends" },
                    { 3, 2000m, 1, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some spends" },
                    { 4, 1000m, 2, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some spends" },
                    { 5, 1500m, 3, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some spends" },
                    { 6, 1200m, 4, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some spends" },
                    { 7, 6000m, 5, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some spends" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenditureRecord",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExpenditureRecord",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExpenditureRecord",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExpenditureRecord",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExpenditureRecord",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ExpenditureRecord",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "ExpenditureRecord",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 1000m);
        }
    }
}
