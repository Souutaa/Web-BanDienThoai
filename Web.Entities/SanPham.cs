using System.ComponentModel.DataAnnotations;

namespace Web.Entities
{
    public class SanPham
    {
        [Key]
        public int Id { get; set; }      
        public string Id_SanPham { get; set; }
        public string Name { get; set; }
        public string Ten_SanPham { get; set; }
        [Required, MaxLength(50)]
        public string Rom { get; set; }
        public double GiaTien { get; set; }
        public int SoLuong { get; set; }
        public string Id_LoaiSanPham {  get; set; } //Loại Sản Phẩm
    }
}