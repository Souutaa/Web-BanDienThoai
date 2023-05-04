using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Persistances.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnSoLuongThayDoiCTHD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoLuongThayDoi",
                table: "ChiTietHoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f281a91e-730b-4a9f-987d-27093e0ca6d8", "AQAAAAIAAYagAAAAEMV5oeziIq1h1VNA/jaFlzy8Q5yzQJTOa/1eHtgdwcDaNE7Km8sYnAH+FXxuVOUtBg==", "2c42e9b1-fe33-496d-9ddb-100f952a8c38" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuongThayDoi",
                table: "ChiTietHoaDon");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b90caa7e-6514-4db1-bdc8-8e1840cabed7", "AQAAAAIAAYagAAAAELRUMTj8SIXSyfKQ9kUxFkSxt9pIjDN9lLDr5ynrEq910QnVd+QWBDFgpAlRB63oYg==", "bf2a86ad-73db-4c2e-8294-9e5f169b9537" });
        }
    }
}
