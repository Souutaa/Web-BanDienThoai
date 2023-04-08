using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.KhachHang
{
    public class CreateKhachHangViewModel
    {
        //"^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$"gm
        [Key]
        [Required(ErrorMessage = "Phải nhập mã Khách Hàng (KH__)")]
        [RegularExpression(@"^[kK][hH][0-9]\S*$"), Display(Name = "Mã Khách Hàng")]
        public string Id_KhacHang { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }       
        [Required, MaxLength(50)] public string Address { get; set; }

        [Required(ErrorMessage = "Phải nhập số điện thoại")]
        [RegularExpression(@"^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$"), Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
    }
}
