using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.CauHinh
{
    public class CreateCauHinhViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã cấu hình (CH__)")]
        [RegularExpression(@"^[cC][hH][0-9]\S*$"), Display(Name = "Mã Cấu Hình")]
        public string Id_CauHinh { get; set; }
        
        public string DoPhanGiai { get; set; }
        public string CameraTruoc { get; set; }
        public string CameraSau { get; set; }
        public string Ram { get; set; }
        public string Chipset { get; set; }
    }
}
