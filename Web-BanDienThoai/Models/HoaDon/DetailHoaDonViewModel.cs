using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Web_BanDienThoai.Models.ChiTietHoaDon;

namespace Web_BanDienThoai.Models.HoaDon
{
    public class DetailHoaDonViewModel
    {
        [ValidateNever]
        public string Id_HoaDon { get; set; }
        public DateTime NgayLapHoaDon { get; set; }
        public double TongTien { get; set; }
        [ForeignKey("KhachHang")] public string Id_khachhang { get; set; }  //Khách Hàng
        [ForeignKey("NhanVien")] public string Id_NhanVien { get; set; }   //Nhân Viên

        [ForeignKey("ChiTietHoaDon")] public string Id_SanPham { get; set; }  
        public IEnumerable<SelectListItem> SanPham { get; set; }
        public List<string> namesp { get; set; }

        public List<Web.Entities.SanPham> sanpham { get; set; }
    }
}
