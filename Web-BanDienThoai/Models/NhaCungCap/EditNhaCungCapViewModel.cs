using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.NhaCungCap
{
    public class EditNhaCungCapViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã nhà cung cấp (NCC__)")]
        [RegularExpression(@"^[nN][cC][cC][0-9]\S*$"), Display(Name = "Mã Nhà Cung Cấp")]
        public string Id_NhaCungCap { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string Phone { get; set; }
    }
}
