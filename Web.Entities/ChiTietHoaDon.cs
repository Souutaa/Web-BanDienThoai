using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class ChiTietHoaDon
    {
        [Key] public int Id { get; set; }
        public string Id_HoaDon { get; set; }  //Hóa Đơn
        public string Id_SanPham { get; set; }  //Sản Phẩm
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
    }
}
