using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Persistances.Migrations
{
    /// <inheritdoc />
    public partial class LoaiSP_tennull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TenLoai",
                table: "LoaiSanPham",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1203059a-c49d-4194-9583-8f7c36b337a0", "AQAAAAIAAYagAAAAEBWHSGZ/s4/EUB1YOClQ/oskKE9E/cdyZAYH01xirtJN5X9lCaf+31t+hMIQADqn6g==", "86d1b5ba-3928-4b78-984b-78fb7119bf15" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TenLoai",
                table: "LoaiSanPham",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96f11a41-815e-4be2-a0af-6c4f808e30c0", "AQAAAAIAAYagAAAAEClakGm7AfPpNaqHH6Vcs/9vI5MaJl9bPAIHiEdPh8EGgXF850Cn603kHsMvyEXT6Q==", "0b90a80e-eb09-4920-a595-418a6b086a3c" });
        }
    }
}
