using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Web.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Web_BanDienThoai.Models.NhapHang
{
    public class CreateNhapHangViewModel
    {
        public CreateNhapHangViewModel() 
        {
            Staffs = new List<SelectListItem>();
        }   

        [Key]
        [Required(ErrorMessage = "Phải nhập mã nhập hàng (NH__)")]
        [RegularExpression(@"^[nN][hH][0-9]\S*$"), Display(Name = "Mã nhập hàng")]
        public string Id_NhapHang { get; set; }

        [DataType(DataType.Date), Display(Name = "Ngày lập đơn nhập hàng")]
        public DateTime NgayLap { get; set; } = DateTime.Now;

        [DataType(DataType.Date), Display(Name = "Ngày giao đơn nhập hàng")]
        public DateTime NgayGiao { get; set; } = DateTime.Now;
        [Display(Name = "Trạng thái nhập hàng:")]
        public TrangThaiNhapHang TrangThaiNhapHang { get; set; }
        [Display(Name = "Tổng tiền:")]
        public double TongTien { get; set; }
        [Display(Name = "Tổng số lượng:")]
        public int TongSoLuong { get; set; }
        [Display(Name = "Ghi chú (Nếu có):")]
        public string? GhiChu { get; set; }

        [Required(ErrorMessage = "Phải nhập mã nhà cung cấp (NCC__)")]
        [RegularExpression(@"^[nN][cC][cC][0-9]\S*$"), Display(Name = "Mã nhà cung cấp")]
        [ForeignKey("NhaCungCap")] 
        public string Id_NhaCungCap { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> NhaCungCap { set; get; }

        public List<SelectListItem> Staffs { get; set; }
        [Display(Name = "Nhân viên:")]
        public string id_nhanvien { get; set; }
    }
}
