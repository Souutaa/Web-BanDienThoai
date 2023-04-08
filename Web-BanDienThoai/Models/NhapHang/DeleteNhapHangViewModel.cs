using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Web.Entities;

namespace Web_BanDienThoai.Models.NhapHang
{
    public class DeleteNhapHangViewModel
    {
        [Key]
        public string Id_NhapHang { get; set; }        
        [ForeignKey("NhaCungCap")] public string Id_NhaCungCap { get; set; }       
        [ForeignKey("NhanVien")] public string Id_NhanVien { get; set; }
    }
}
