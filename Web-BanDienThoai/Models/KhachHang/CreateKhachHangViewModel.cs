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

        [Required(ErrorMessage = "Phải nhập Tên Khách Hàng")]
        [Display(Name = "Tên Khách Hàng")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Phải nhập Họ Khách Hàng")]
        [Display(Name = "Họ Khách Hàng")]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + /*(string.IsNullOrEmpty(MiddleName) ? " " : (" " + (char?)MiddleName[0] + ". ").ToUpper()) +*/ LastName;
                // FirstName + " "(nếu MiddleName rỗng) / kí tự đầu( nếu MiddleName không rỗng) sau đó viết hoa + LastName
            }
        }

        [Required(ErrorMessage = "Phải giới tính")]
        [Display(Name = "Giới Tính")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phải nhập ngày/tháng/năm sinh")]
        [Display(Name = "Ngày/Tháng/Năm Sinh")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Phải nhập Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phải nhập địa chỉ")]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phải nhập số điện thoại")]
        [RegularExpression(@"^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$"), Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
    }
}
