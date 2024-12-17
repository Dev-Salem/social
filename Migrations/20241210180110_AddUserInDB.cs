using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace social.Migrations
{
    /// <inheritdoc />
    public partial class AddUserInDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "388940d0-e23c-44d2-bdec-c11f4a499120");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2597f81-e7ef-48e8-a819-908f6074f01b");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d3ada90-089f-41f8-b6d3-eb5dedbec41b", null, "Admin", "ADMIN" },
                    { "dacc908d-f085-4c5e-b47a-dd8d8f6836d4", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3ada90-089f-41f8-b6d3-eb5dedbec41b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dacc908d-f085-4c5e-b47a-dd8d8f6836d4");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "388940d0-e23c-44d2-bdec-c11f4a499120", null, "User", "USER" },
                    { "e2597f81-e7ef-48e8-a819-908f6074f01b", null, "Admin", "ADMIN" }
                });
        }
    }
}
