﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_BanDienThoai.Models.DanhMucCon
{
    public class EditDanhMucConViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã danh mục con (DMC__)")]
        [RegularExpression(@"^[dD][mM][cC][0-9]\S*$"), Display(Name = "Mã Danh Mục Con")]
        public string Id_DanhMucCon { get; set; }
        [Display(Name = "Tên Danh Mục Con")]
        public string TenDanhMuc { get; set; }

        [Display(Name = "Mã Cấu Hình")]
        [Required]
        [ForeignKey("CauHinh")]
        public /*List<String>*/ string Id_CauHinh { get; set; }  //Cấu Hình
                                                                 ////public CauHinh cauHinh { get; set; };
        [ValidateNever]
        public IEnumerable<SelectListItem> CauHinh { set; get; }
    }
}
