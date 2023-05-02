using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Persistances.Migrations
{
    /// <inheritdoc />
    public partial class updateStatusHoaDon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_AspNetUsers_Id_NhanVien",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_SanPham_SanPhamId_SanPham",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_SanPhamId_SanPham",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "SanPhamId_SanPham",
                table: "HoaDon");

            migrationBuilder.AlterColumn<string>(
                name: "Id_NhanVien",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b90caa7e-6514-4db1-bdc8-8e1840cabed7", "AQAAAAIAAYagAAAAELRUMTj8SIXSyfKQ9kUxFkSxt9pIjDN9lLDr5ynrEq910QnVd+QWBDFgpAlRB63oYg==", "bf2a86ad-73db-4c2e-8294-9e5f169b9537" });

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_AspNetUsers_Id_NhanVien",
                table: "HoaDon",
                column: "Id_NhanVien",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_AspNetUsers_Id_NhanVien",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "status",
                table: "HoaDon");

            migrationBuilder.AlterColumn<string>(
                name: "Id_NhanVien",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanPhamId_SanPham",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7da74f4-2969-45c7-a68f-08f65dcdbf8f", "AQAAAAIAAYagAAAAECaC5hF/XtnBOqnIhhq5m7ffcdh8fbNGy+RG68gV/wGcfbseVghkv9m1GHigbxPESw==", "c2377b7b-7895-4d7f-ab53-6b7f7fceabef" });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_SanPhamId_SanPham",
                table: "HoaDon",
                column: "SanPhamId_SanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_AspNetUsers_Id_NhanVien",
                table: "HoaDon",
                column: "Id_NhanVien",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_SanPham_SanPhamId_SanPham",
                table: "HoaDon",
                column: "SanPhamId_SanPham",
                principalTable: "SanPham",
                principalColumn: "Id_SanPham");
        }
    }
}
