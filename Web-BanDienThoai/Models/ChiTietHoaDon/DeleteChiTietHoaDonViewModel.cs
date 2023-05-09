using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.ChiTietHoaDon
{
    public class DeleteChiTietHoaDonViewModel
    {
        [Display(Name = "Mã hóa đơn")]
        public string Id_HoaDon { get; set; }  //Hóa Đơn
        [Display(Name = "Mã sản phẩm")]
        public string Id_SanPham { get; set; }  //Sản Phẩm
        [Display(Name = "SoLuong")]
        public int SoLuong { get; set; }                                  //
    }
}
