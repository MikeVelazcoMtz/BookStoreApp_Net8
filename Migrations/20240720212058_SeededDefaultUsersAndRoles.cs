using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08ac7a49-6936-4147-94a2-a059a8c93f33", null, "User", "USER" },
                    { "7e5d8142-6078-4efc-bcb4-f142e8ce3602", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7c704548-862c-4956-b79d-38b6992b30b0", 0, "388464c9-1d76-4cbe-b8fe-c438afc108d2", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEG9dEi2rOH4x2SwmgzD3Hq9W6ajeW3rpnugtwb37lSoVzB65VLmk0rm8nO1ERe/+dA==", null, false, "8dc78a05-d95a-49bd-9b2c-37e5bcc6bbfb", false, "admin@bookstore.com" },
                    { "a8c91e4a-9805-43b9-8021-62226162b1a9", 0, "fd2e9823-c218-4620-824f-7b7183c8c88c", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEPMuVfgn30xmlL3Nm04YTaaJi2yM5CZub6HZPHBYjE/7rcqup7Lhawp5t5FmYqA7wA==", null, false, "a1ce7bca-804c-41bc-a504-c02b0f8953c6", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "08ac7a49-6936-4147-94a2-a059a8c93f33", "7c704548-862c-4956-b79d-38b6992b30b0" },
                    { "7e5d8142-6078-4efc-bcb4-f142e8ce3602", "a8c91e4a-9805-43b9-8021-62226162b1a9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "08ac7a49-6936-4147-94a2-a059a8c93f33", "7c704548-862c-4956-b79d-38b6992b30b0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7e5d8142-6078-4efc-bcb4-f142e8ce3602", "a8c91e4a-9805-43b9-8021-62226162b1a9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08ac7a49-6936-4147-94a2-a059a8c93f33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e5d8142-6078-4efc-bcb4-f142e8ce3602");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c704548-862c-4956-b79d-38b6992b30b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8c91e4a-9805-43b9-8021-62226162b1a9");
        }
    }
}
