using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class DanhMucCon
    {
        [Key]
        public int Id { get; set; }
        public string Id_DanhMucCon { get; set; }
        public string TenDanhMuc { get; set; }
        public string Id_CauHinh { get; set; }  //Cấu Hình
    }
}
