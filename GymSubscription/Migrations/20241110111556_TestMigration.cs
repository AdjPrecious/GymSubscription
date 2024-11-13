using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymSubscription.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckInTime",
                table: "Attendances",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Attendances",
                type: "time",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27d74b76-109f-4642-8ef6-8744a02f3673", null, "User", "USER" },
                    { "4bee9130-e370-4bda-8b2a-9412a29bae4c", null, "Trainer", "TRAINER" },
                    { "e844d8f9-be39-443f-afd6-7f5a0823f826", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27d74b76-109f-4642-8ef6-8744a02f3673");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bee9130-e370-4bda-8b2a-9412a29bae4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e844d8f9-be39-443f-afd6-7f5a0823f826");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Attendances");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckInTime",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
