﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Web_BanDienThoai.Models.HoaDon
{
    public class CreateHoaDonViewModel
    {
        public CreateHoaDonViewModel()
        {
            Users = new List<SelectListItem>();
            Staffs = new List<SelectListItem>();
        }

        public List<SelectListItem> Users { get; set; }
        public List<SelectListItem> Staffs { get; set; }

        [Key]
        [Required(ErrorMessage = "Phải nhập mã Hóa Đơn (HD__)"), Display(Name = "Mã Hóa Đơn")]
        //[RegularExpression(@"^[hH][dD][0-9]\S*$"), Display(Name = "Mã Hóa Đơn")]
        public string Id_HoaDon { get; set; }

        [DataType(DataType.Date), Display(Name = "Ngày lập hóa đơn")]
        public DateTime NgayLapHoaDon { get; set; } = DateTime.Now;
        [Display(Name ="Tổng tiền")]        
        
        public double TongTien { get; set; }
        [Display(Name = "Khách hàng:")]
        public string Id_khachhang { get; set; }  //Khách Hàng
        [Display(Name = "Nhân viên:")]
        public string Id_NhanVien { get; set; }   //Nhân Viên
    }
}
