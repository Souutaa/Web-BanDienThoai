using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.SanPham
{
    public class DetailSanPhamViewModel
    {       
        public string Id_SanPham { get; set; }       
        public string Ten_SanPham { get; set; }
        public string ImageUrl { get; set; }        
        public double GiaTien { get; set; }
        public int SoLuong { get; set; }
        public string Rom { get; set; }
        public string Id_loai { get; set; } //Loại Sản Phẩm    

    }
}
