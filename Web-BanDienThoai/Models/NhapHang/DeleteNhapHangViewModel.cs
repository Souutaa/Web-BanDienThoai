using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Web.Entities;

namespace Web_BanDienThoai.Models.NhapHang
{
    public class DeleteNhapHangViewModel
    {
        [Key]
        public string Id_NhapHang { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayGiao { get; set; }
    }
}
