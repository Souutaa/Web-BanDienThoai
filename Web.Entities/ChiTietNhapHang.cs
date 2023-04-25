using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Entities
{
    [PrimaryKey(nameof(Id_SanPham), nameof(Id_NhapHang))]
    public class ChiTietNhapHang
    {
        [Key, Column(Order = 0)] public string Id_SanPham { get; set; } //Sản Phẩm
        [Key, Column(Order = 1)] public string Id_NhapHang { get; set; } //Nhập Hàng
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }

        public virtual SanPham SanPham { get; set; }
        public virtual NhapHang NhapHang { get; set; }
    }
}
