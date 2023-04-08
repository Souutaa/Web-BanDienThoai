using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.NhanVien
{
    public class EditNhanVienViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã nhân viên")]
        [RegularExpression(@"^[nN][vV][0-9]\S*$"), Display(Name = "Mã Nhân Viên")]
        public string Id_NhanVien { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.Date), Display(Name = "Ngày/Tháng/Năm Sinh")]
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        [Required, MaxLength(50)] public string Address { get; set; }
        public string Phone { get; set; }
    }
}
