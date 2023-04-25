using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.TaiKhoan
{
    public class IndexTaiKhoanViewModel : IdentityUser
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; }
    }
}
