﻿using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.NhaCungCap
{
    public class DetailNhaCungCapViewModel
    {      
        public string Id_NhaCungCap { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }       
        public string Phone { get; set; }
    }
}
