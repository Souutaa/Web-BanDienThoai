using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entities
{
    public enum TrangThaiDonHang
    {
        [Display(Name = "Đang xử lí")]
        pending = 0,
        [Display(Name = "Đã xử lí")]
        finished,
        [Display(Name = "Đã giao")]
        delivered,
        [Display(Name = "Đã Hủy")]
        canceled,
    }
}
