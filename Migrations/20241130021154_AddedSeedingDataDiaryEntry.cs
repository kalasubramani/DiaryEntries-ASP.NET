using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiaryApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataDiaryEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "Created", "Title" },
                values: new object[,]
                {
                    { 1, "Went hiking with my dog!", new DateTime(2024, 11, 29, 21, 11, 54, 327, DateTimeKind.Local).AddTicks(5574), "Went Hiking" },
                    { 2, "Went shopping with my friend Joe!", new DateTime(2024, 11, 29, 21, 11, 54, 327, DateTimeKind.Local).AddTicks(5833), "Went Shopping" },
                    { 3, "Went diving with my family!", new DateTime(2024, 11, 29, 21, 11, 54, 327, DateTimeKind.Local).AddTicks(5836), "Went Diving" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
