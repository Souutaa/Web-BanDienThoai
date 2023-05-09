using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.ChiTietNhapHang
{
    public class DeleteChiTietNhapHangViewModel
    {
        [Display(Name = "Mã sản phẩm")]
        public string Id_SanPham { get; set; } //Sản Phẩm

        [Display(Name = "Mã nhập hàng")]
        public string Id_NhapHang { get; set; } //Nhập Hàng

        [Display(Name = "Số lượng")]
        public double SoLuong { get; set; }                                        //
    }
}
