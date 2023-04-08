using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.DanhMucCon
{
    public class EditDanhMucConViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập danh mục con (DMC__)")]
        [RegularExpression(@"^[dD][mM][cC][0-9]\S*$"), Display(Name = "Mã Danh Mục Con")]
        public string Id_DanhMucCon { get; set; }
        public string TenDanhMuc { get; set; }
       
        [Required(ErrorMessage = "Phải nhập mã cấu hình (CH__)")]
        [RegularExpression(@"^[cC][hH][0-9]\S*$"), Display(Name = "Mã cấu hình")]        
        [ForeignKey("CauHinh")] public string Id_CauHinh { get; set; } //Cấu Hình
    }
}
