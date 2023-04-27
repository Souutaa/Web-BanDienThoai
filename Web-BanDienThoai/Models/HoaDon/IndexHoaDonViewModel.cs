using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.HoaDon
{
    public class IndexHoaDonViewModel
    {
        public string Id_HoaDon { get; set; }
        public DateTime NgayLapHoaDon { get; set; }
        public double TongTien { get; set; }
        //[ForeignKey("KhachHang")] public string Id_khachhang { get; set; }  //Khách Hàng   
        public string FullName_khachhang { get; set; }
        public string FullName_NhanVien { get; set; }
        //[ForeignKey("NhanVien")] public string Id_NhanVien { get; set; }   //Nhân Viên

    }
}
