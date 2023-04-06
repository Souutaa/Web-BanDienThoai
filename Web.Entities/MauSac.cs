using System.ComponentModel.DataAnnotations;

namespace Web.Entities
{
    public class MauSac
    {
        [Key] public string Id_MauSac { get; set; }
        public string TenMauSac { get; set; }
    }
}
