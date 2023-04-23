﻿using Azure.Messaging;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.SanPham
{
    public class CreateSanPhamViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã sản phẩm (ID_SanPham)")]
        [RegularExpression(@"^[a-zA-Z]{2}[0-9]\S*$"), Display(Name = "Mã sản phẩm")]
        public string Id_SanPham { get; set; }

        [Required(ErrorMessage = "Phải nhập tên sản phẩm")]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "Tên Sản Phẩm")]
        public string Ten_SanPham { get; set; }     
        public IFormFile ImageUrl { get; set; }
        [Display(Name = "Giá tiền")]
        public double GiaTien { get; set; }

        [Required(ErrorMessage = "Phải nhập số lượng sản phẩm")]
        [Display(Name = "Số lượng sản phẩm")]
        [RegularExpression(@"^[0-9]\d*$")]
        public int SoLuong { get; set; }
        public string Rom { get; set; }

        [Required(ErrorMessage = "Phải nhập mã loại sản phẩm")]
        [RegularExpression(@"^[Ll][Ss][Pp][0-9]\S*$", ErrorMessage ="Phải nhập theo cú pháp LSP__"), Display(Name = "Mã loại sản phẩm")]
        public string? Id_loai { get; set; } //Loại Sản Phẩm

        [ValidateNever]
        public IEnumerable<SelectListItem>? LoaiSanPham { get; set; }
        
    }
}
