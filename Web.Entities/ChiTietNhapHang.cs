using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class ChiTietNhapHang
    {
        [Key] public int Id { get; set; }
        public string Id_SanPham { get; set; } //Sản Phẩm
        public string Id_NhapHang { get; set; } //Nhập Hàng
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
    }
}
