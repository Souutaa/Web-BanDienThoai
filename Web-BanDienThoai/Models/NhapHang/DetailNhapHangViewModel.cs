using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Web.Entities;

namespace Web_BanDienThoai.Models.NhapHang
{
    public class DetailNhapHangViewModel
    {       
        public string Id_NhapHang { get; set; }        
        public DateTime NgayLap { get; set; }
        public DateTime NgayGiao { get; set; }
        public TrangThaiNhapHang TrangThaiNhapHang { get; set; }
        public double TongTien { get; set; }
        public int TongSoLuong { get; set; }
        public string GhiChu { get; set; }
        public string Id_NhaCungCap { get; set; }
        public string Id_NhanVien { get; set; }
        public List<Web.Entities.SanPham> sanphamnhaphang { get; set; }
    }
}
