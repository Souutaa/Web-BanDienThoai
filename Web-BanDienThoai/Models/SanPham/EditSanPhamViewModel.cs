using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.SanPham
{
    public class EditSanPhamViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã sản phẩm (ID_SanPham)"), StringLength(10, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]{2}[0-9]\S*$"), Display(Name = "Mã sản phẩm")]
        public string Id_SanPham { get; set; }

        [Required(ErrorMessage = "Phải nhập tên sản phẩm"), StringLength(80, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "Tên Sản Phẩm")]
        public string Ten_SanPham { get; set; }
        public IFormFile ImageUrl { get; set; }
        [Display(Name = "Giá tiền")]
        public double GiaTien { get; set; }

        [Display(Name = "Số lượng sản phẩm")]
        public int SoLuong { get; set; }
        public string Rom { get; set; }

        [Required(ErrorMessage = "Phải nhập mã loại sản phẩm"), StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[Ll][Ss][Pp][0-9]\S*$"), Display(Name = "Mã loại sản phẩm")]
        public string Id_LoaiSanPham { get; set; } //Loại Sản Phẩm

        [ValidateNever]
        public IEnumerable<SelectListItem>? LoaiSanPham { get; set; }
    }
}
