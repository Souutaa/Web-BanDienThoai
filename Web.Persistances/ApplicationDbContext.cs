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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        
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
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        /// Nhập Hàng
        /// </summary>
    }
}
