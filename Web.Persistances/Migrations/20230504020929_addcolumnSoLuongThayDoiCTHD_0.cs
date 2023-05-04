using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Persistances.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnSoLuongThayDoiCTHD_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96f11a41-815e-4be2-a0af-6c4f808e30c0", "AQAAAAIAAYagAAAAEClakGm7AfPpNaqHH6Vcs/9vI5MaJl9bPAIHiEdPh8EGgXF850Cn603kHsMvyEXT6Q==", "0b90a80e-eb09-4920-a595-418a6b086a3c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f281a91e-730b-4a9f-987d-27093e0ca6d8", "AQAAAAIAAYagAAAAEMV5oeziIq1h1VNA/jaFlzy8Q5yzQJTOa/1eHtgdwcDaNE7Km8sYnAH+FXxuVOUtBg==", "2c42e9b1-fe33-496d-9ddb-100f952a8c38" });
        }
    }
}
