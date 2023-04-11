using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Persistances.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CauHinh",
                columns: table => new
                {
                    Id_CauHinh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoPhanGiai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CameraTruoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CameraSau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHinh", x => x.Id_CauHinh);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    Id_HoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_SanPham = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    ThanhTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => new { x.Id_HoaDon, x.Id_SanPham });
                });

            migrationBuilder.CreateTable(
                name: "ChiTietNhapHang",
                columns: table => new
                {
                    Id_SanPham = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_NhapHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    ThanhTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietNhapHang", x => new { x.Id_SanPham, x.Id_NhapHang });
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Id_KhacHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id_KhacHang);
                });

            migrationBuilder.CreateTable(
                name: "MauSac",
                columns: table => new
                {
                    Id_MauSac = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenMauSac = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSac", x => x.Id_MauSac);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    Id_NhaCungCap = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.Id_NhaCungCap);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id_NhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id_NhanVien);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucCon",
                columns: table => new
                {
                    Id_DanhMucCon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_CauHinh = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucCon", x => x.Id_DanhMucCon);
                    table.ForeignKey(
                        name: "FK_DanhMucCon_CauHinh_Id_CauHinh",
                        column: x => x.Id_CauHinh,
                        principalTable: "CauHinh",
                        principalColumn: "Id_CauHinh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    Id_HoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayLapHoaDon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false),
                    Id_khachhang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_NhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.Id_HoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_Id_khachhang",
                        column: x => x.Id_khachhang,
                        principalTable: "KhachHang",
                        principalColumn: "Id_KhacHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien_Id_NhanVien",
                        column: x => x.Id_NhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "Id_NhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhapHang",
                columns: table => new
                {
                    Id_NhapHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThaiNhapHang = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false),
                    TongSoLuong = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_NhaCungCap = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_NhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhapHang", x => x.Id_NhapHang);
                    table.ForeignKey(
                        name: "FK_NhapHang_NhaCungCap_Id_NhaCungCap",
                        column: x => x.Id_NhaCungCap,
                        principalTable: "NhaCungCap",
                        principalColumn: "Id_NhaCungCap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhapHang_NhanVien_Id_NhanVien",
                        column: x => x.Id_NhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "Id_NhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPham",
                columns: table => new
                {
                    Id_loai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_DanhMucCon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_MauSac = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPham", x => x.Id_loai);
                    table.ForeignKey(
                        name: "FK_LoaiSanPham_DanhMucCon_Id_DanhMucCon",
                        column: x => x.Id_DanhMucCon,
                        principalTable: "DanhMucCon",
                        principalColumn: "Id_DanhMucCon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoaiSanPham_MauSac_Id_MauSac",
                        column: x => x.Id_MauSac,
                        principalTable: "MauSac",
                        principalColumn: "Id_MauSac",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id_SanPham = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_SanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaTien = table.Column<double>(type: "float", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Id_LoaiSanPham = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id_SanPham);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiSanPham_Id_LoaiSanPham",
                        column: x => x.Id_LoaiSanPham,
                        principalTable: "LoaiSanPham",
                        principalColumn: "Id_loai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucCon_Id_CauHinh",
                table: "DanhMucCon",
                column: "Id_CauHinh");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_Id_khachhang",
                table: "HoaDon",
                column: "Id_khachhang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_Id_NhanVien",
                table: "HoaDon",
                column: "Id_NhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPham_Id_DanhMucCon",
                table: "LoaiSanPham",
                column: "Id_DanhMucCon");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPham_Id_MauSac",
                table: "LoaiSanPham",
                column: "Id_MauSac");

            migrationBuilder.CreateIndex(
                name: "IX_NhapHang_Id_NhaCungCap",
                table: "NhapHang",
                column: "Id_NhaCungCap");

            migrationBuilder.CreateIndex(
                name: "IX_NhapHang_Id_NhanVien",
                table: "NhapHang",
                column: "Id_NhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_Id_LoaiSanPham",
                table: "SanPham",
                column: "Id_LoaiSanPham");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "ChiTietNhapHang");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "NhapHang");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "LoaiSanPham");

            migrationBuilder.DropTable(
                name: "DanhMucCon");

            migrationBuilder.DropTable(
                name: "MauSac");

            migrationBuilder.DropTable(
                name: "CauHinh");
        }
    }
}
