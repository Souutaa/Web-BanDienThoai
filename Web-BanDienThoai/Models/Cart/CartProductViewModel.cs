
namespace Web_BanDienThoai.Models.Cart
{
    public class CartProductViewModel
    {
        public string Id_SanPham { get; set; }

        public long SoLuongSanPham { get; set; }

        public double SubTotal { get; set; }
        // gia san pham * so luong
    }
}
