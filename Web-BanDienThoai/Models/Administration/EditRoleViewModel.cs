using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.Administration
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string RoleId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Role name is required!")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
