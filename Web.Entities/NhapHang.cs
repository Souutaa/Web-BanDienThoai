using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class NhapHang
    {
        [Key]
        public int Id { get; set; }
        public string Id_NhapHang { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayGiao { get; set; }
        public TrangThaiNhapHang TrangThaiNhapHang { get; set; }
        public double TongTien { get; set; }
        public int TongSoLuong { get; set; }
        public string GhiChu { get; set; }
        public string Id_NhaCungCap { get; set; }
        public string Id_NhanVien { get; set; }
    }
}
