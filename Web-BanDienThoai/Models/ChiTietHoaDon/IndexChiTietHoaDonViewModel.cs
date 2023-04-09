using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.ChiTietHoaDon
{
    public class IndexChiTietHoaDonViewModel
    {
        public string Id_HoaDon { get; set; }  //Hóa Đơn
        public string Id_SanPham { get; set; }  //Sản Phẩm
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
    }
}
