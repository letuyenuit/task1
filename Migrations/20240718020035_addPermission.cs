using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace netcore_devsecops.Migrations
{
    /// <inheritdoc />
    public partial class addPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "IdPermission", "IdRole", "IsAccessed" },
                values: new object[,]
                {
                    { new Guid("f49ac10b-68cc-4372-a567-0e02b2c3d479"), new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479"), true },
                    { new Guid("f87ac10b-67cc-4372-a567-0e02b2c3d479"), new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479"), true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "IdPermission", "IdRole" },
                keyValues: new object[] { new Guid("f49ac10b-68cc-4372-a567-0e02b2c3d479"), new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479") });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "IdPermission", "IdRole" },
                keyValues: new object[] { new Guid("f87ac10b-67cc-4372-a567-0e02b2c3d479"), new Guid("f47ac10b-68cc-4372-a567-0e02b2c3d479") });
        }
    }
}
