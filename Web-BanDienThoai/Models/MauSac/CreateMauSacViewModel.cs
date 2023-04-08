using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.MauSac
{
    public class CreateMauSacViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã Màu Sắc (MS__)")]
        [RegularExpression(@"^[mM][sS][0-9]\S*$"), Display(Name = "Mã Màu Sắc")]
        public string Id_MauSac { get; set; }
        public string TenMauSac { get; set; }
    }
}
