using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.LoaiSanPham
{
    public class DetailLoaiSanPhamViewModel
    {
        public string Id_loai { get; set; }
        public string TenLoai { get; set; }
        public string Id_DanhMucCon { get; set; }  //Danh Mục Con
        public string Id_MauSac { get; set; }  //màu sắc
    }
}
