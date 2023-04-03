using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class HoaDon
    {
        [Key]
        public int Id { get; set; }
        public int Id_HoaDon { get; set; }
        public DateTime NgayLapHoaDon { get; set; }
        public double TongTien { get; set; }
        public string Id_khachhang { get; set; }  //Khách Hàng
        public string Id_NhanVien { get; set; }   //Nhân Viên
    }
}
