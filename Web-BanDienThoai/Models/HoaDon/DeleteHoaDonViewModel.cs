using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Web_BanDienThoai.Models.HoaDon
{
    public class DeleteHoaDonViewModel
    {
        [Key]
        public string Id_HoaDon { get; set; }
        [ValidateNever]      
        
        public string Id_NhanVien { get; set; }
        [ValidateNever]      
        public string Id_KhachHang { get; set; }
        
        [ValidateNever]      
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
