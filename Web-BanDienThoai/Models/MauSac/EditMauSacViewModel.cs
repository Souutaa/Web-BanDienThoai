using System.ComponentModel.DataAnnotations;

namespace Web_BanDienThoai.Models.MauSac
{
    public class EditMauSacViewModel
    {
        [Key] public string Id_MauSac { get; set; }
        public string TenMauSac { get; set; }
    }
}
