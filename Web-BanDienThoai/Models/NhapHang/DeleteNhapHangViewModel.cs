using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Web.Entities;

namespace Web_BanDienThoai.Models.NhapHang
{
    public class DeleteNhapHangViewModel
    {
        [Key]
        [Display(Name = "Mã nhập hàng:")]
        public string Id_NhapHang { get; set; }
        [Display(Name = "Ngày lập:")]
        public DateTime NgayLap { get; set; }
        [Display(Name = "Ngày giao:")]
        public DateTime NgayGiao { get; set; }
    }
}
