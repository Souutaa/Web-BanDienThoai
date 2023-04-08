using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.KhachHang
{
    public class DeleteKhachHangViewModel
    {
        [Key]
        public string Id_KhacHang { get; set; }
        public string FullName { get; set; }       
    }
}
