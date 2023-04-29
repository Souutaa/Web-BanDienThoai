using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.HoaDon
{
    public class DeleteHoaDonViewModel
    {
        [Key]
        public string Id_HoaDon { get; set; }
        public DateTime NgayLapHoaDon { get; set; }


    }
}
