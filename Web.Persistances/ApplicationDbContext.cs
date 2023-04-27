using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;


namespace Web.Persistances
{
    public class ApplicationDbContext : IdentityDbContext
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
            builder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "2ca8fa08-4a80-4714-a5fb-17b7316fddc4",
                Name = "Admin",
                NormalizedName = "ADMIN".ToUpper()
            },
            new IdentityRole
            {
                Id = "88ac3925-8432-4f60-89e2-96433d08bbcf",
                Name = "Manager",
                NormalizedName = "MANAGER".ToUpper()
            }
            );
            var hasher = new PasswordHasher<TaiKhoan>();

            builder.Entity<TaiKhoan>().HasData(
               new TaiKhoan
               {
                   Id = "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                   UserName = "Super Admin",
                   NormalizedUserName = "SUPER ADMIN".ToUpper(),
                   Email = "admin@gmail.com",
                   NormalizedEmail = "ADMIN@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Admin@123")
               }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>
                {
                    UserId = "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                    RoleId = "2ca8fa08-4a80-4714-a5fb-17b7316fddc4"
                },
                new IdentityUserRole<string>
                {
                    UserId = "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                    RoleId = "88ac3925-8432-4f60-89e2-96433d08bbcf"
                }


            );
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
