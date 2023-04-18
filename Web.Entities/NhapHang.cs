using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Entities
{
    public class NhapHang
    {
        [Key]
        public string Id_NhapHang { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayGiao { get; set; }
        public TrangThaiNhapHang TrangThaiNhapHang { get; set; }
        public double TongTien { get; set; }
        public int TongSoLuong { get; set; }
        public string GhiChu { get; set; }
        //[ForeignKey("SanPham")] public string Id_SanPham { get; set; }
        //public SanPham? SanPham { get; set; }
        [ForeignKey("NhaCungCap")] public string Id_NhaCungCap { get; set; }
        public NhaCungCap? NhaCungCap { get; set; }
        [ForeignKey("NhanVien")] public string Id_NhanVien { get; set; }
        public NhanVien? NhanVien { get; set; }
        
    }
}
