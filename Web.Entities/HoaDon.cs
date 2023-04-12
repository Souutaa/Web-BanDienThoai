﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Entities
{
    public class HoaDon
    {
        [Key]
        public string Id_HoaDon { get; set; }
        public DateTime NgayLapHoaDon { get; set; }
        public double TongTien { get; set; }
        [ForeignKey("SanPham")] public string Id_SanPham { get; set; }
        public SanPham? SanPham { get; set; }
        [ForeignKey("KhachHang")] public string Id_khachhang { get; set; }  //Khách Hàng
        public KhachHang? KhachHang { get; set; }
        [ForeignKey("NhanVien")] public string Id_NhanVien { get; set; }   //Nhân Viên
        public NhanVien? NhanVien { get; set; }
    }
}
