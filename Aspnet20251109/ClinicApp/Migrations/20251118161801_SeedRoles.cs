using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad90e18a-ab7f-4bb0-9f73-5778de3b4a1f", "ad90e18a-ab7f-4bb0-9f73-5778de3b4a1f", "APP_ADMIN", "APP_ADMIN" },
                    { "ad90e18a-ab7f-4bb0-9f74-5778de3b4a1f", "ad90e18a-ab7f-4bb0-9f74-5778de3b4a1f", "DOCTOR", "DOCTOR" },
                    { "ad90e18a-ab7f-4bb0-9f75-5778de3b4a1f", "ad90e18a-ab7f-4bb0-9f75-5778de3b4a1f", "RECEPTIONIST", "RECEPTIONIST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ad90e18a-ab7f-4bb0-9f73-5778de3b4a1f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ad90e18a-ab7f-4bb0-9f74-5778de3b4a1f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ad90e18a-ab7f-4bb0-9f75-5778de3b4a1f");
        }
    }
}
