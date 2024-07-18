using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace netcore_devsecops.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "IdPermission", "Name" },
                values: new object[,]
                {
                    { new Guid("f49ac10b-68cc-4372-a567-0e02b2c3d479"), "finance" },
                    { new Guid("f87ac10b-67cc-4372-a567-0e02b2c3d479"), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "IdRole", "Name" },
                values: new object[,]
                {
                    { new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479"), "ADMIN" },
                    { new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479"), "FINANCER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "Email", "IdRole", "Password", "RoleIdRole" },
                values: new object[,]
                {
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "letuyenkhtn212@gmail.com", new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479"), "1234", null },
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d487"), "test@gmail.com", new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479"), "1234", null }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "IdPermission", "IdRole", "IsAccessed" },
                values: new object[,]
                {
                    { new Guid("f49ac10b-68cc-4372-a567-0e02b2c3d479"), new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479"), true },
                    { new Guid("f87ac10b-67cc-4372-a567-0e02b2c3d479"), new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479"), true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "IdPermission", "IdRole" },
                keyValues: new object[] { new Guid("f49ac10b-68cc-4372-a567-0e02b2c3d479"), new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479") });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "IdPermission", "IdRole" },
                keyValues: new object[] { new Guid("f87ac10b-67cc-4372-a567-0e02b2c3d479"), new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "IdRole",
                keyValue: new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d487"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "IdPermission",
                keyValue: new Guid("f49ac10b-68cc-4372-a567-0e02b2c3d479"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "IdPermission",
                keyValue: new Guid("f87ac10b-67cc-4372-a567-0e02b2c3d479"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "IdRole",
                keyValue: new Guid("f47ac10b-67cc-4372-a567-0e02b2c3d479"));
        }
    }
}
