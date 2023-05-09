using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Web_BanDienThoai.Models.HoaDon
{
    public class DeleteHoaDonViewModel
    {
        [Key]
        [Display(Name = "Mã hóa đơn")]
        public string Id_HoaDon { get; set; }
        [ValidateNever]

        [Display(Name = "Nhân viên")]
        public string Id_NhanVien { get; set; }

        [Display(Name = "Khách Hàng")]
        [ValidateNever]      
        public string Id_KhachHang { get; set; }
        
        [ValidateNever]
        [Display(Name = "Tình trạng hóa đơn")]
        public string Status { get; set; }

        [Display(Name = "Ngày lập hóa đơn")]
        public DateTime CreatedAt { get; set; }

    }
}
