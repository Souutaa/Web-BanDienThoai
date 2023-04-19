using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.CauHinh
{
    public class EditCauHinhViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã cấu hình (CH__)")]
        [RegularExpression(@"^[cC][hH][0-9]\S*$"), Display(Name = "Mã Cấu Hình:")]
        public string Id_CauHinh { get; set; }

        [Required(ErrorMessage = "Phải nhập độ phân giải màn hình"), Display(Name = "Độ phân giải màn hình:")]
        public string DoPhanGiai { get; set; }

        [Required(ErrorMessage = "Phải nhập độ phân giải camera trước"), Display(Name = "Độ phân giải camera trước:")]
        public string CameraTruoc { get; set; }

        [Required(ErrorMessage = "Phải nhập độ phân giải camera sau"), Display(Name = "Độ phân giải camera sau:")]
        public string CameraSau { get; set; }

        [Required(ErrorMessage = "Phải nhập ram"), Display(Name = "Ram:")]
        public string Ram { get; set; }

        [Required(ErrorMessage = "Phải nhập chipset"), Display(Name = "Chipset:")]
        public string Chipset { get; set; }
    }
}
