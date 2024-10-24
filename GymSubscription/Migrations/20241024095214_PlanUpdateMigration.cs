using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymSubscription.Migrations
{
    /// <inheritdoc />
    public partial class PlanUpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76e5dad4-0408-4e7b-a89d-f3313eba4b2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9902e0a-8d47-4074-92f1-5b1be7afa85f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6b66494-318d-4b29-bf46-6fb290a3b4f5");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Plans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d2cc635-b2d0-4b97-994d-c133a410ed37", null, "Trainer", "TRAINER" },
                    { "36294cea-ca39-4fe8-a0f0-b3badfdba0ef", null, "Admin", "ADMIN" },
                    { "8c215806-d108-499c-b1c7-a83043c6ddcd", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d2cc635-b2d0-4b97-994d-c133a410ed37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36294cea-ca39-4fe8-a0f0-b3badfdba0ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c215806-d108-499c-b1c7-a83043c6ddcd");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Plans");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76e5dad4-0408-4e7b-a89d-f3313eba4b2d", null, "Trainer", "TRAINER" },
                    { "b9902e0a-8d47-4074-92f1-5b1be7afa85f", null, "User", "USER" },
                    { "c6b66494-318d-4b29-bf46-6fb290a3b4f5", null, "Admin", "ADMIN" }
                });
        }
    }
}
