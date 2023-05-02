using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Entities
{
    public class HoaDon
    {
        [Key]
        public string Id_HoaDon { get; set; }
        public DateTime NgayLapHoaDon { get; set; }
        public double TongTien { get; set; }

        public TrangThaiDonHang status { get; set; } 
        //public virtual SanPham? SanPham { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [ForeignKey("KhachHang")]
        public string Id_khachhang { get; set; }
        public virtual TaiKhoan KhachHang { get; set; }

        [ForeignKey("NhanVien")]
        public string? Id_NhanVien { get; set; }

        public virtual TaiKhoan NhanVien { get; set; }
    }
}
