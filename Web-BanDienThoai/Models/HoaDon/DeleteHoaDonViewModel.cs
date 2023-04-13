using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.HoaDon
{
    public class DeleteHoaDonViewModel
    {
        [Key]
        public string Id_HoaDon { get; set; }      
        [ForeignKey("KhachHang")] public string Id_khachhang { get; set; }  //Khách Hàng       
        [ForeignKey("NhanVien")] public string Id_NhanVien { get; set; }   //Nhân Viên
    }
}
