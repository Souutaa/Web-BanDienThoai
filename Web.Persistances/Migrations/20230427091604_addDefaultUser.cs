using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Persistances.Migrations
{
    /// <inheritdoc />
    public partial class addDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1222788e-f7bb-46f4-9839-1ef40ff2b116", null, "Admin", "ADMIN" },
                    { "88ac3925-8432-4f60-89e2-96433d08bbcf", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ff045d07-be86-4a4e-bfa4-0264ec832c12", 0, "d7da74f4-2969-45c7-a68f-08f65dcdbf8f", "TaiKhoan", "admin@gmail.com", false, null, false, null, "ADMIN@GMAIL.COM", "SUPER ADMIN", "AQAAAAIAAYagAAAAECaC5hF/XtnBOqnIhhq5m7ffcdh8fbNGy+RG68gV/wGcfbseVghkv9m1GHigbxPESw==", null, false, "c2377b7b-7895-4d7f-ab53-6b7f7fceabef", false, "Super Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1222788e-f7bb-46f4-9839-1ef40ff2b116", "ff045d07-be86-4a4e-bfa4-0264ec832c12" },
                    { "88ac3925-8432-4f60-89e2-96433d08bbcf", "ff045d07-be86-4a4e-bfa4-0264ec832c12" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1222788e-f7bb-46f4-9839-1ef40ff2b116", "ff045d07-be86-4a4e-bfa4-0264ec832c12" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "88ac3925-8432-4f60-89e2-96433d08bbcf", "ff045d07-be86-4a4e-bfa4-0264ec832c12" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1222788e-f7bb-46f4-9839-1ef40ff2b116");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ac3925-8432-4f60-89e2-96433d08bbcf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12");
        }
    }
}
