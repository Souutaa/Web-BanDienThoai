using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Web.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Web_BanDienThoai.Models.NhapHang
{
    public class CreateNhapHangViewModel
    {
        public CreateNhapHangViewModel() {
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
        public TrangThaiNhapHang TrangThaiNhapHang { get; set; }
        public double TongTien { get; set; }
        public int TongSoLuong { get; set; }
        public string? GhiChu { get; set; }

        [Required(ErrorMessage = "Phải nhập mã nhà cung cấp (NCC__)")]
        [RegularExpression(@"^[nN][cC][cC][0-9]\S*$"), Display(Name = "Mã nhà cung cấp")]
        [ForeignKey("NhaCungCap")] 
        public string Id_NhaCungCap { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> NhaCungCap { set; get; }

        public List<SelectListItem> Staffs { get; set; }
        public string id_staff { get; set; }
    }
}
