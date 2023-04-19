using System.ComponentModel.DataAnnotations;

namespace Web.Entities
{
    public enum TrangThaiNhapHang
    {
        [Display(Name = "Đang xử lí")]
        dangxuli,
        [Display(Name = "Đang giao")]
        danggiao,
        [Display(Name = "Đã giao")]
        dagiao
    }
}