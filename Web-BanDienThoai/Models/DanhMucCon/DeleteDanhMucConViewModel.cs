﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.DanhMucCon
{
    public class DeleteDanhMucConViewModel
    {
        public string Id_DanhMucCon { get; set; }
        public string TenDanhMuc { get; set; }
        //[ForeignKey("CauHinh")] public string Id_CauHinh { get; set; }  //Cấu Hình
    }
}
