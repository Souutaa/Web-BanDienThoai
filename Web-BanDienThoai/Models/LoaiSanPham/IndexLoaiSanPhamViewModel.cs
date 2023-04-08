using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.LoaiSanPham
{
    public class IndexLoaiSanPhamViewModel
    {
        public string Id_loai { get; set; }
        public string TenLoai { get; set; }
        [ForeignKey("DanhMucCon")] public string Id_DanhMucCon { get; set; }  //Danh Mục Con     
        [ForeignKey("MauSac")] public string Id_MauSac { get; set; }  //Danh Mục Con
    }
}

