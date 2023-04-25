using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class TaiKhoan : IdentityUser
    {
        [PersonalData]
        public string? FullName { get; set; }
    }
}
