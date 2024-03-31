using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addSomeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExpenditureRecord",
                columns: new[] { "Id", "Amount", "CategoryId", "Date", "Description" },
                values: new object[] { 1, 1000m, 1, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some spends" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenditureRecord",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
