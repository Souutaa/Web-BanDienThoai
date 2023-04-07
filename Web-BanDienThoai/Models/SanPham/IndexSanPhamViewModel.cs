using Web.Entities;
namespace Web_BanDienThoai.Models.SanPham
{
    public class IndexSanPhamViewModel
    {
        public string Id_SanPham { get; set; }
        public string Ten_SanPham { get; set; }
        public string ImageUrl { get; set; }
        public string Rom { get; set; }
        public double GiaTien { get; set; }
    }
}
