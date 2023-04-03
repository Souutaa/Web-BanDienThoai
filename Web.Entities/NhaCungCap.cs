using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }
        public int Id_NhaCungCap { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string Phone { get; set; }
    }
}
