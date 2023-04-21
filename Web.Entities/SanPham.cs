using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Entities
{
    public class SanPham
    {
        [Key]
        public string Id_SanPham { get; set; }
        public string Ten_SanPham { get; set; }
        public string ImageUrl { get; set; }
        public string Rom { get; set; }
        public double GiaTien { get; set; }
        public int SoLuong { get; set; }
        [ForeignKey("LoaiSanPham")] public string Id_loai { get; set; } //Loại Sản Phẩm
        public virtual LoaiSanPham? LoaiSanPham { get; set; }
        public virtual ICollection<ChiTietNhapHang> ChiTietNhapHangs { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}