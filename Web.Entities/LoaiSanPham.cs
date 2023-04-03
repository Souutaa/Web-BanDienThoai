using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class LoaiSanPham
    {
        [Key]
        public int Id { get; set; }
        public string Id_loai { get; set; }
        public string TenLoai { get; set; }
        public string Id_DanhMucCon { get; set; }  //Danh Mục Con

    }
}
