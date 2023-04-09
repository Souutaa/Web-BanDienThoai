using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.ChiTietHoaDon
{
    public class DeleteChiTietHoaDonViewModel
    {
        public string Id_HoaDon { get; set; }  //Hóa Đơn
        public string Id_SanPham { get; set; }  //Sản Phẩm        
    }
}
