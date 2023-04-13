using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_BanDienThoai.Models.HoaDon
{
    public class EditHoaDonViewModel
    {
        [Key]
        [Required(ErrorMessage = "Phải nhập mã Hóa Đơn (HD__)")]
        [RegularExpression(@"^[hH][dD][0-9]\S*$"), Display(Name = "Mã Hóa Đơn")]
        public string Id_HoaDon { get; set; }
       
        [DataType(DataType.Date), Display(Name = "Ngày lập hóa đơn")]
        public DateTime NgayLapHoaDon { get; set; }
       
        public double TongTien { get; set; }
        [Required(ErrorMessage = "Phải nhập mã khách hàng (KH__)")]
        [RegularExpression(@"^[kK][hH][0-9]\S*$"), Display(Name = "Mã Khách Hàng")]
        [ForeignKey("KhachHang")] public string Id_khachhang { get; set; }  //Khách Hàng
        public IEnumerable<SelectListItem> KhachHang { set; get; }

        [Required(ErrorMessage = "Phải nhập mã Nhân Viên (NV__)")]
        [RegularExpression(@"^[nN][vV][0-9]\S*$"), Display(Name = "Mã Nhân Viên")]
        [ForeignKey("NhanVien")] public string Id_NhanVien { get; set; }   //Nhân Viên
        public IEnumerable<SelectListItem> NhanVien { set; get; }
    }
}
