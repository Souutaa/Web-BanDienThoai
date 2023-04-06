using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Web.Entities
{
    [PrimaryKey(nameof(Id_SanPham), nameof(Id_NhapHang))]
    public class ChiTietNhapHang
    {
        [Key] public string Id_SanPham { get; set; } //Sản Phẩm
        [Key] public string Id_NhapHang { get; set; } //Nhập Hàng
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
    }
}
