using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Entities
{
    public class DanhMucCon
    {
        [Key]
        public string Id_DanhMucCon { get; set; }
        public string TenDanhMuc { get; set; }
        [ForeignKey("CauHinh")] public string /*List<String>*/ Id_CauHinh { get; set; }  //Cấu Hình
        public CauHinh? CauHinh { get; set; }
    }
}
