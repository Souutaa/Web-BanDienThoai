using Microsoft.Build.Framework;

namespace Web_BanDienThoai.Models.TaiKhoan
{
    public class LoginTaiKhoanViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
