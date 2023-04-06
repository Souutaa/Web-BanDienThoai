using System.ComponentModel.DataAnnotations;

namespace Web.Entities
{
    public class CauHinh
    {
        [Key]
        public string Id_CauHinh { get; set; }
        public string DoPhanGiai { get; set; }
        public string CameraTruoc { get; set; }
        public string CameraSau { get; set; }
        public string Ram { get; set; }
        public string Chipset { get; set; }
    }
}
