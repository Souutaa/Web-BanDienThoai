using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Persistances.Migrations
{
    /// <inheritdoc />
    public partial class QuangLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_SanPham_Id_SanPham",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_Id_SanPham",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "Id_SanPham",
                table: "HoaDon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id_SanPham",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_Id_SanPham",
                table: "HoaDon",
                column: "Id_SanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_SanPham_Id_SanPham",
                table: "HoaDon",
                column: "Id_SanPham",
                principalTable: "SanPham",
                principalColumn: "Id_SanPham",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
