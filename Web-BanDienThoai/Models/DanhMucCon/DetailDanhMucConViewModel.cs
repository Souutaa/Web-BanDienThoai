using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.DanhMucCon
{
    public class DetailDanhMucConViewModel
    {
        public string Id_DanhMucCon { get; set; }
        [Display(Name = "Tên Danh Mục Con")]
        public string TenDanhMuc { get; set; }
        public /*List<String>*/ string Id_CauHinh { get; set; }
    }   
}
