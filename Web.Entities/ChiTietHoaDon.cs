using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Web.Entities
{
    [PrimaryKey(nameof(Id_HoaDon), nameof(Id_SanPham))]
    public class ChiTietHoaDon
    {
        [Key] public string Id_HoaDon { get; set; }  //Hóa Đơn
        [Key] public string Id_SanPham { get; set; }  //Sản Phẩm
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
    }
}
