﻿using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.NhanVien
{
    public class DetailNhanVienViewModel
    {
        public string Id_NhanVien { get; set; }        
        public string FullName { get; set; }
        public string Gender { get; set; }        
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
