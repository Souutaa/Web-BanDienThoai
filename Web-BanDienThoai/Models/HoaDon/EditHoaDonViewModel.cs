using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Web_BanDienThoai.Models.HoaDon
{
    public class EditHoaDonViewModel
    {

        public EditHoaDonViewModel() {
            Staffs = new List<SelectListItem>();
            Customers = new List<SelectListItem>();
        }

        public string Id_HoaDon { get; set; }
       
        [DataType(DataType.Date), Display(Name = "Ngày lập hóa đơn")]
        public DateTime NgayLapHoaDon { get; set; }
        [Display(Name =" Tổng tiền")]
        public double TongTien { get; set; }
        public string Id_customer { get; set; }  //Khách Hàng
        public List<SelectListItem> Customers { set; get; }
        
        public string Id_staff { get; set; }   //Nhân Viên
        public List<SelectListItem> Staffs { set; get; }
    }
}
