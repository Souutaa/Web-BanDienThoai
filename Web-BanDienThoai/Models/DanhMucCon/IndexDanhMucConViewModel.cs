using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.DanhMucCon
{
    public class IndexDanhMucConViewModel
    {
        public string Id_DanhMucCon { get; set; }
        public string TenDanhMuc { get; set; }
        [ForeignKey("CauHinh")] public List<String> Id_CauHinh { get; set; }  //Cấu Hình
    }
}
