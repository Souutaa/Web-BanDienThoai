using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Entities
{
    public class LoaiSanPham
    {
        [Key]
        public string Id_loai { get; set; }
        public string TenLoai { get; set; }
        [ForeignKey("DanhMucCon")] public string Id_DanhMucCon { get; set; }  //Danh Mục Con
        public virtual DanhMucCon? DanhMucCon { get; set; }
        [ForeignKey("MauSac")] public string Id_MauSac { get; set; }  //Danh Mục Con
        public virtual MauSac? MauSac { get; set; }
    }
}
