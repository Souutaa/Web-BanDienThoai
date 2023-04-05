using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.SanPham
{
    public class IndexSanPhamViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Ten_SanPham { get; set; }
        [Required, MaxLength(50)]
        public string ImageUrl { get; set; }
        public string Rom { get; set; }
        public double GiaTien { get; set; }
    }
}
