using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Persistances.Migrations
{
    /// <inheritdoc />
    public partial class updateForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id_NhapHang",
                table: "ChiTietNhapHang",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "Id_SanPham",
                table: "ChiTietNhapHang",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "Id_SanPham",
                table: "ChiTietHoaDon",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "Id_HoaDon",
                table: "ChiTietHoaDon",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhapHang_Id_NhapHang",
                table: "ChiTietNhapHang",
                column: "Id_NhapHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_Id_SanPham",
                table: "ChiTietHoaDon",
                column: "Id_SanPham");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_Id_HoaDon",
                table: "ChiTietHoaDon",
                column: "Id_HoaDon",
                principalTable: "HoaDon",
                principalColumn: "Id_HoaDon",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_SanPham_Id_SanPham",
                table: "ChiTietHoaDon",
                column: "Id_SanPham",
                principalTable: "SanPham",
                principalColumn: "Id_SanPham",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietNhapHang_NhapHang_Id_NhapHang",
                table: "ChiTietNhapHang",
                column: "Id_NhapHang",
                principalTable: "NhapHang",
                principalColumn: "Id_NhapHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietNhapHang_SanPham_Id_SanPham",
                table: "ChiTietNhapHang",
                column: "Id_SanPham",
                principalTable: "SanPham",
                principalColumn: "Id_SanPham",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_Id_HoaDon",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_SanPham_Id_SanPham",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietNhapHang_NhapHang_Id_NhapHang",
                table: "ChiTietNhapHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietNhapHang_SanPham_Id_SanPham",
                table: "ChiTietNhapHang");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietNhapHang_Id_NhapHang",
                table: "ChiTietNhapHang");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_Id_SanPham",
                table: "ChiTietHoaDon");

            migrationBuilder.AlterColumn<string>(
                name: "Id_NhapHang",
                table: "ChiTietNhapHang",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "Id_SanPham",
                table: "ChiTietNhapHang",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "Id_SanPham",
                table: "ChiTietHoaDon",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "Id_HoaDon",
                table: "ChiTietHoaDon",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);
        }
    }
}
