using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymSubscription.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payment_PlanID",
                table: "Payment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1da902f7-f8e6-4be6-b98f-36e2fd203fca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b838d95c-ca15-49b6-8a96-55c790222e30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f15cdbe8-e03a-4c46-9929-5a7e60079db0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "449aafe4-b3c0-45a1-90eb-ecdd679693a2", null, "Admin", "ADMIN" },
                    { "5f085c32-ab3a-4ea7-8b70-700bbf420d4b", null, "Trainer", "TRAINER" },
                    { "febc2a07-a9e2-4169-8cbb-04d093b1be36", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PlanID",
                table: "Payment",
                column: "PlanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payment_PlanID",
                table: "Payment");

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
                    { "1da902f7-f8e6-4be6-b98f-36e2fd203fca", null, "Trainer", "TRAINER" },
                    { "b838d95c-ca15-49b6-8a96-55c790222e30", null, "Admin", "ADMIN" },
                    { "f15cdbe8-e03a-4c46-9929-5a7e60079db0", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PlanID",
                table: "Payment",
                column: "PlanID",
                unique: true);
        }
    }
}
