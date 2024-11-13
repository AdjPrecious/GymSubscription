using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymSubscription.Migrations
{
    /// <inheritdoc />
    public partial class IsDeletedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Plans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3787507f-85f5-4c1d-9b5b-a21caa7ee0ed", null, "Admin", "ADMIN" },
                    { "b471590e-a04e-4b8b-ab94-9d9e36d7bd3d", null, "User", "USER" },
                    { "fe726114-6a77-4159-bd3b-76586464b671", null, "Trainer", "TRAINER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3787507f-85f5-4c1d-9b5b-a21caa7ee0ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b471590e-a04e-4b8b-ab94-9d9e36d7bd3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe726114-6a77-4159-bd3b-76586464b671");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Plans");

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
    }
}
