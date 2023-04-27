using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.NhaCungCap
{
    public class CreateNhaCungCapViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã nhà cung cấp (NCC__)")]
        [RegularExpression(@"^[nN][cC][cC][0-9]\S*$"), Display(Name = "Mã Nhà Cung Cấp")]
        public string Id_NhaCungCap { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Address { get; set; }
        

        [Required(ErrorMessage = "Phải nhập số điện thoại")]
        [RegularExpression(@"^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$"), Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
    }
}
