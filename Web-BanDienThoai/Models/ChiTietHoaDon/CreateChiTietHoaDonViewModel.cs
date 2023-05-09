using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace Web_BanDienThoai.Models.ChiTietHoaDon
{
    public class CreateChiTietHoaDonViewModel
    {
        //[ForeignKey("HoaDon")]
        [Key]
        [Display(Name = "Mã hóa đơn:")]
        public string Id_HoaDon { get; set; }  //Hóa Đơn
        [ValidateNever]
        public IEnumerable<SelectListItem> HoaDon { set; get; }

        //[ForeignKey("SanPham")]
        [Key] 
        [Display(Name = "Sản Phẩm:")]
        public string Id_SanPham { get; set; }  //Sản Phẩm
        [ValidateNever]
        public IEnumerable<SelectListItem> SanPham { set; get; }

        [Required(ErrorMessage = "Phải nhập số lượng"), Display(Name = "Số Lượng:")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Phải nhập đơn giá"), Display(Name = "Đơn giá:")]
        public double DonGia { get; set; }

        [Display(Name = "Thành tiền:")]
        public double ThanhTien
        {
            get
            {
                return SoLuong * DonGia;
            }
        }

            
    }
}
