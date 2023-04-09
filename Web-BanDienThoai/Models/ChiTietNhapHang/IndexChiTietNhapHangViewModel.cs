using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.ChiTietNhapHang
{
    public class IndexChiTietNhapHangViewModel
    {      
        public string Id_SanPham { get; set; } //Sản Phẩm
        public string Id_NhapHang { get; set; } //Nhập Hàng
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
    }
}
