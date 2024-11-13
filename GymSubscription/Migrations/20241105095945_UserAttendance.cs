using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymSubscription.Migrations
{
    /// <inheritdoc />
    public partial class UserAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "449aafe4-b3c0-45a1-90eb-ecdd679693a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f085c32-ab3a-4ea7-8b70-700bbf420d4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "febc2a07-a9e2-4169-8cbb-04d093b1be36");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "190dcf2e-1b7d-4b5f-beca-8b9308b7c989", null, "Trainer", "TRAINER" },
                    { "7d97e664-6bed-46ca-8cb5-de87488dbf69", null, "Admin", "ADMIN" },
                    { "a03cd803-d5f4-4462-bb8a-e7797383c467", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "190dcf2e-1b7d-4b5f-beca-8b9308b7c989");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d97e664-6bed-46ca-8cb5-de87488dbf69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03cd803-d5f4-4462-bb8a-e7797383c467");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "449aafe4-b3c0-45a1-90eb-ecdd679693a2", null, "Admin", "ADMIN" },
                    { "5f085c32-ab3a-4ea7-8b70-700bbf420d4b", null, "Trainer", "TRAINER" },
                    { "febc2a07-a9e2-4169-8cbb-04d093b1be36", null, "User", "USER" }
                });
        }
    }
}
