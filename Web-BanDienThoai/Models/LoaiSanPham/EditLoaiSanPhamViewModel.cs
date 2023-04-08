using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.LoaiSanPham
{
    public class EditLoaiSanPhamViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã loại sản phẩm (LSP__)")]
        [RegularExpression(@"^[lL][sS][pP][0-9]\S*$"), Display(Name = "Mã Loại Sản Phẩm")]
        public string Id_loai { get; set; }
        public string TenLoai { get; set; }

        [Required(ErrorMessage = "Phải nhập mã danh mục con (DMC__)")]
        [RegularExpression(@"^[dD][mM][cC][0-9]\S*$"), Display(Name = "Mã Danh Mục Con")]
        [ForeignKey("DanhMucCon")] public string Id_DanhMucCon { get; set; }  //Danh Mục Con
                                                                              //
        [Required(ErrorMessage = "Phải nhập mã màu sắc (MS__)")]
        [RegularExpression(@"^[mM][sS][0-9]\S*$"), Display(Name = "Mã Màu Sắc")]
        [ForeignKey("MauSac")] public string Id_MauSac { get; set; }  //màu sắc
    }
}
}
