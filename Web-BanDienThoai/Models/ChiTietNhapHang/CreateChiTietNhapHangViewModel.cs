using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.ChiTietNhapHang
{
    public class CreateChiTietNhapHangViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã sản phẩm (ID_SanPham)"), StringLength(10, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]{2}[0-9]\S*$"), Display(Name = "Mã sản phẩm")]
        public string Id_SanPham { get; set; } //Sản Phẩm

        [Key]
        [Required(ErrorMessage = "Phải nhập mã nhập hàng")]
        [RegularExpression(@"^[nN][hH][0-9]\S*$"), Display(Name = "Mã nhập hàng")]
        public string Id_NhapHang { get; set; } //Nhập Hàng

        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        //public double ThanhTien { get; set; }
        public double ThanhTien { 
            get
            {
                 return SoLuong* DonGia;
            }
        }
    }
}
