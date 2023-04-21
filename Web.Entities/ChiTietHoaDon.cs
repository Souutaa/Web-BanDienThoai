using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Entities
{
    [PrimaryKey(nameof(Id_HoaDon), nameof(Id_SanPham))]

    public class ChiTietHoaDon
    {
        [Key, Column(Order = 0)] public string Id_HoaDon { get; set; }  //Hóa Đơn
        [Key, Column(Order = 1)] public string Id_SanPham { get; set; }  //Sản Phẩm

        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
