using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.SanPham
{
    public class EditSanPhamViewModel
    {
        [Key]
        public string Id_SanPham { get; set; }
        [Required(ErrorMessage = "Phải nhập mã sản phẩm (ID_SanPham)"), StringLength(10, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]{2}[0-9]\S*$"), Display(Name = "Mã sản phẩm")]
        public string Ten_SanPham { get; set; }
        [Required(ErrorMessage = "Phải nhập tên sản phẩm"), StringLength(80, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "Tên Sản Phẩm")]
        public IFormFile ImageUrl { get; set; }
        public double GiaTien { get; set; }
        [Display(Name = "Giá tiền")]
        public int SoLuong { get; set; }
        [Display(Name = "Số lượng sản phẩm")]
        public string Id_LoaiSanPham { get; set; } //Loại Sản Phẩm
        [Required(ErrorMessage = "Phải nhập mã loại sản phẩm"), StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[Ll][Ss][Pp][0-9]\S*$"), Display(Name = "Mã loại sản phẩm")]
        public string Rom { get; set; }
    }
}
