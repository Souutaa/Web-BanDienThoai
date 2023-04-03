using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Persistances
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<NhanVien> NhanVien { get; set; }/// <summary>
        /// Nhân Viên
        /// </summary>
        
        public DbSet<KhachHang> KhachHang { get; set; } /// <summary>
        /// Khách Hang
        /// </summary>
        
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<MauSac> MauSac { get; set; }
        public DbSet<DanhMucCon> DanhMucCon { get; set; }
        public DbSet<CauHinh> CauHinh { get; set; }/// <summary>
        /// Sản Phẩm
        /// </summary>
        
        public DbSet<NhaCungCap> NhaCungCap { get; set; }/// <summary>
        /// Nhà Cung Cấp
        /// </summary>
        
        public DbSet<HoaDon> HoaDon { get; set; } 
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }/// <summary>
        /// Hóa Đơn
        /// </summary>
        
        public DbSet<NhapHang> NhapHang { get; set; }
        public DbSet<ChiTietNhapHang> ChiTietNhapHang { get; set; }/// <summary>
        /// Nhập Hàng
        /// </summary>
    }
}
