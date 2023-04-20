using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.ChiTietHoaDon
{
    public class EditChiTietHoaDonViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã Hóa Đơn (HD__)")]
        [RegularExpression(@"^[hH][dD][0-9]\S*$"), Display(Name = "Mã Hóa Đơn")]
        public string Id_HoaDon { get; set; }  //Hóa Đơn
        [ValidateNever]
        public IEnumerable<SelectListItem> HoaDon { set; get; }

        [Key]
        [Required(ErrorMessage = "Phải nhập mã sản phẩm (ID_SanPham)"), StringLength(10, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]{2}[0-9]\S*$"), Display(Name = "Mã sản phẩm")]
        public string Id_SanPham { get; set; }  //Sản Phẩm
        [ValidateNever]
        public IEnumerable<SelectListItem> SanPham { set; get; }
        [Required(ErrorMessage = "Phải nhập số lượng"), Display(Name = "Số Lượng:")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Phải nhập đơn giá"), Display(Name = "Đơn giá:")]
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
    }
}
