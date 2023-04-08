using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.LoaiSanPham
{
    public class DeleteLoaiSanPhamViewModel
    {
        public string Id_loai { get; set; }
        public string TenLoai { get; set; }      
    }
}

