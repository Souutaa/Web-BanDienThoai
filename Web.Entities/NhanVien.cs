using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class NhanVien
    {
        [Key]
        public int Id { get; set; }
        public string Id_NhanVien { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string Phone { get; set; }
    }
}
