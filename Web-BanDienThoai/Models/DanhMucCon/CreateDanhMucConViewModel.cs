using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Web.Entities;

namespace Web_BanDienThoai.Models.DanhMucCon
{
    public class CreateDanhMucConViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã danh mục con (DMC__)")]
        [RegularExpression(@"^[dD][mM][cC][0-9]\S*$"), Display(Name = "Mã Danh Mục Con")]
        public string Id_DanhMucCon { get; set; }
       
        public string TenDanhMuc { get; set; }
        [ForeignKey("CauHinh")] public string Id_CauHinh { get; set; }  //Cấu Hình        
    }
}
