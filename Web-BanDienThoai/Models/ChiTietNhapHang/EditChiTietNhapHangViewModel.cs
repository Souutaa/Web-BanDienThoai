using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_BanDienThoai.Models.ChiTietNhapHang
{
    public class EditChiTietNhapHangViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã sản phẩm (ID_SanPham)")]
        [RegularExpression(@"^[a-zA-Z]{2}[0-9]\S*$"), Display(Name = "Mã sản phẩm")]
        public string Id_SanPham { get; set; } //Sản Phẩm

        [Key]
        [Required(ErrorMessage = "Phải nhập mã nhập hàng")]
        [RegularExpression(@"^[nN][hH][0-9]\S*$"), Display(Name = "Mã nhập hàng")]
        public string Id_NhapHang { get; set; } //Nhập Hàng

        [Required(ErrorMessage = "Phải nhập số lượng"), Display(Name = "Số Lượng:")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Phải nhập đơn giá"), Display(Name = "Đơn giá:")]
        public double DonGia { get; set; }
        public double ThanhTien
        {
            get
            {
                return SoLuong * DonGia;
            }
        }
    }
}
