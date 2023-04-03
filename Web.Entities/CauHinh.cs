using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class CauHinh
    {
        [Key]
        public int Id { get; set; }
        public string Id_CauHinh { get; set; }      
        public string DoPhanGiai { get; set; }
        public string CameraTruoc { get; set; }
        public string CameraSau { get; set; }       
        public string Ram { get; set; }
        public string Chipset { get; set; }
    }
}
