using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace Web_BanDienThoai.Models.CauHinh
{
    public class IndexCauHinhViewModel
    {
        public string Id_CauHinh { get; set; }
        public string DoPhanGiai { get; set; }
        public string CameraTruoc { get; set; }
        public string CameraSau { get; set; }
        public string Ram { get; set; }
        public string Chipset { get; set; }
        
    }
}
