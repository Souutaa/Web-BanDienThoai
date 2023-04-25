using Microsoft.Build.Framework;

namespace Web_BanDienThoai.Models.Administration
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
