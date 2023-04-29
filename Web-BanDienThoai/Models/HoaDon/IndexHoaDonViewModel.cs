using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.HoaDon
{
    public class IndexHoaDonViewModel
    {
        public string Id_HoaDon { get; set; }
        public DateTime NgayLapHoaDon { get; set; }
        public double TongTien { get; set; }
        public string id_khachhang { get; set; }
        public string id_NhanVien { get; set; }

    }
}
