using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Persistances.Migrations
{
    /// <inheritdoc />
    public partial class GhiChuNhapHangnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "NhapHang",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54ee22a7-985d-4b0c-a786-e92cc6a75c06", "AQAAAAIAAYagAAAAEBytZ4XjJ0b78q/yIOfn6wMUI+VOLtD7tXpTd0tvRd1ztrFAgUA3h6t/fKb8wgpmQg==", "a07be2c2-a98b-4a60-848f-48ad12bdb682" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "NhapHang",
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
                values: new object[] { "1203059a-c49d-4194-9583-8f7c36b337a0", "AQAAAAIAAYagAAAAEBWHSGZ/s4/EUB1YOClQ/oskKE9E/cdyZAYH01xirtJN5X9lCaf+31t+hMIQADqn6g==", "86d1b5ba-3928-4b78-984b-78fb7119bf15" });
        }
    }
}
