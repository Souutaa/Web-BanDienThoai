using System.ComponentModel.DataAnnotations;

namespace Web.Entities
{
    public class KhachHang
    {
        [Key]
        public string Id_KhacHang { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        [Required, MaxLength(50)] public string Address { get; set; }
        public string Phone { get; set; }
    }
}
